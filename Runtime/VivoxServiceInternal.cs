using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Authentication.Internal;
#if AUTH_PACKAGE_PRESENT
using Unity.Services.Authentication;
#endif
using Unity.Services.Core;
using Unity.Services.Vivox.AudioTaps;
using Unity.Services.Vivox.Internal;
using Unity.Services.Vivox.Mint;
using Unity.Services.Vivox.Mint.Apis.Default;
using Unity.Services.Vivox.Mint.Default;
using Unity.Services.Vivox.Mint.Http;
using System.Runtime.CompilerServices;

namespace Unity.Services.Vivox
{
    class VivoxServiceInternal : IVivoxServiceInternal
    {
        public event Action AvailableInputDevicesChanged;
        public event Action EffectiveInputDeviceChanged;
        public event Action AvailableOutputDevicesChanged;
        public event Action EffectiveOutputDeviceChanged;
        public event Action LoggedIn;
        public event Action LoggedOut;
        public event Action ConnectionRecovering;
        public event Action ConnectionRecovered;
        public event Action ConnectionFailedToRecover;
        public event Action<string> ChannelJoined;
        public event Action<string> ChannelLeft;
        public event Action<VivoxParticipant> ParticipantAddedToChannel;
        public event Action<VivoxParticipant> ParticipantRemovedFromChannel;
        public event Action<VivoxMessage> SpeechToTextMessageReceived;
        public event Action<VivoxMessage> ChannelMessageReceived;
        public event Action<VivoxMessage> ChannelMessageEdited;
        public event Action<VivoxMessage> ChannelMessageDeleted;
        public event Action<VivoxMessage> DirectedMessageReceived;
        public event Action<VivoxMessage> DirectedMessageEdited;
        public event Action<VivoxMessage> DirectedMessageDeleted;

        public bool IsLoggedIn => m_LoginSession != null && m_LoginSession.State == LoginState.LoggedIn;
        public string SignedInPlayerId => IsLoggedIn ? m_LoginSession.LoginSessionId.Name : string.Empty;
        public bool IsAudioEchoCancellationEnabled => Client.Initialized && Client.IsAudioEchoCancellationEnabled;
        public ReadOnlyDictionary<string, ReadOnlyCollection<VivoxParticipant>> ActiveChannels
            => new ReadOnlyDictionary<string, ReadOnlyCollection<VivoxParticipant>>(m_ActiveChannels.ToDictionary(pair => pair.Key, pair => pair.Value.AsReadOnly()));
        public string LastChannelJoinedUri => m_LastChannelJoinedUri;
        public ReadOnlyCollection<string> TransmittingChannels => GetTransmittingChannels();

        public ReadOnlyCollection<string> TextToSpeechAvailableVoices =>
            IsLoggedIn ? new ReadOnlyCollection<string>(m_LoginSession.TTS.AvailableVoices.Select(ttsVoice => ttsVoice.Name).ToList()) : new List<string>().AsReadOnly();
        public string TextToSpeechCurrentVoice => IsLoggedIn ? m_LoginSession.TTS.CurrentVoice.Name : string.Empty;

        public VivoxInputDevice ActiveInputDevice => Client.Initialized ? new VivoxInputDevice(Client.AudioInputDevices.ActiveDevice) : null;
        public VivoxInputDevice EffectiveInputDevice => Client.Initialized ? new VivoxInputDevice(Client.AudioInputDevices.EffectiveDevice) : null;
        public VivoxOutputDevice ActiveOutputDevice => Client.Initialized ? new VivoxOutputDevice(Client.AudioOutputDevices.ActiveDevice) : null;
        public VivoxOutputDevice EffectiveOutputDevice => Client.Initialized ? new VivoxOutputDevice(Client.AudioOutputDevices.EffectiveDevice) : null;
        public ReadOnlyCollection<VivoxInputDevice> AvailableInputDevices => GetInputDevices();
        public ReadOnlyCollection<VivoxOutputDevice> AvailableOutputDevices => GetOutputDevices();
        public int InputDeviceVolume => Client.Initialized ? Client.AudioInputDevices.VolumeAdjustment : 0;
        public int OutputDeviceVolume => Client.Initialized ? Client.AudioOutputDevices.VolumeAdjustment : 0;
        public bool IsInputDeviceMuted => Client.Initialized && Client.AudioInputDevices.Muted;
        public bool IsOutputDeviceMuted => Client.Initialized && Client.AudioOutputDevices.Muted;
        public bool IsInjectingAudio => m_LoginSession != null && m_LoginSession.IsInjectingAudio;

        public event Action<bool> UserInputDeviceMuteStateChanged;

        public IosVoiceProcessingIOModes IosVoiceProcessingIOMode => GetIosVoiceProcessingIOMode();

        /// <summary>
        /// Keys used to fetch Vivox credentials.
        /// </summary>
        public const string k_ServerKey = "com.unity.services.vivox.server";
        public const string k_DomainKey = "com.unity.services.vivox.domain";
        public const string k_IssuerKey = "com.unity.services.vivox.issuer";
        public const string k_TokenKey = "com.unity.services.vivox.token";
        public const string k_EnvironmentCustomKey = "com.unity.services.vivox.is-environment-custom";
        public const string k_TestModeKey = "com.unity.services.vivox.is-test-mode";

        public const string k_MustBeLoggedInErrorMessage = "You must be logged in to perform this operation.";

        // This is used to determine if we will attempt to generate local Vivox Access Tokens (VATs).
        // If we have a Key, Edit > Project Settings > Services > Vivox > Test Mode is true and we will generate debug Vivox Access Tokens locally.
        public bool IsTestMode { get; set; }

        public string AccessToken => AccessTokenComponent?.AccessToken;
        public string PlayerId => PlayerIdComponent?.PlayerId;
        public string EnvironmentId => EnvironmentIdComponent?.EnvironmentId;
        public bool IsAuthenticated => !string.IsNullOrEmpty(PlayerId) && !string.IsNullOrEmpty(EnvironmentId);

        public Client Client { get; set; }
        public string Server { get; set; }
        public string Domain { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public bool IsEnvironmentCustom { get; }
        public bool HaveVivoxCredentials => !(string.IsNullOrEmpty(Issuer) && string.IsNullOrEmpty(Domain) && string.IsNullOrEmpty(Server));

        public IAccessToken AccessTokenComponent { get; }
        public IPlayerId PlayerIdComponent { get; }
        public IEnvironmentId EnvironmentIdComponent { get; }
        public IVivoxTokenProviderInternal InternalTokenProvider { get; set; }
        public IVivoxTokenProvider ExternalTokenProvider { get; set; }

        bool m_AuthCallbacksConnected = false;
        bool m_Initialized;
        ILoginSession m_LoginSession;
        Dictionary<string, List<VivoxParticipant>> m_ActiveChannels = new Dictionary<string, List<VivoxParticipant>>();
        string m_LastChannelJoinedUri = string.Empty;

        public VivoxServiceInternal(
            string server,
            string domain,
            string issuer,
            string token,
            bool isEnvironmentCustom,
            bool isTestMode,
            IAccessToken accessTokenComponent,
            IPlayerId playerIdComponent,
            IEnvironmentId environmentIdComponent)
        {
            if (playerIdComponent != null)
            {
                PlayerIdComponent = playerIdComponent;
            }
            if (accessTokenComponent != null)
            {
                AccessTokenComponent = accessTokenComponent;
            }
            if (environmentIdComponent != null)
            {
                EnvironmentIdComponent = environmentIdComponent;
            }
            if (string.IsNullOrEmpty(server))
            {
                VivoxLogger.LogException(new ArgumentException($"'{nameof(server)}' is null or empty", nameof(server)));
                return;
            }
            if (string.IsNullOrEmpty(domain))
            {
                VivoxLogger.LogException(new ArgumentException($"'{nameof(domain)}' is null or empty", nameof(domain)));
            }
            if (string.IsNullOrEmpty(issuer))
            {
                VivoxLogger.LogException(new ArgumentException($"'{nameof(issuer)}' is null or empty", nameof(issuer)));
            }

            Server = server;
            Domain = domain;
            Issuer = issuer;
            Key = token;
            IsEnvironmentCustom = isEnvironmentCustom;
            IsTestMode = isTestMode;
        }

        public async Task InitializeAsync(VivoxConfigurationOptions options = null)
        {
            if (m_Initialized)
            {
                return;
            }

            string uriString = Server;

            // If custom credentials are in use, do not modify the Server Uri.
            if (!IsEnvironmentCustom)
            {
                // If endpoint pulled in from udash is an /appconfig URI, append the Environment ID fragment.
                // Leave the URI alone if it's an /api2 endpoint.
                if (!uriString.EndsWith("/api2"))
                {
                    string environmentFragment = $"/{EnvironmentId}";
                    uriString += environmentFragment;
                }
            }

            Client = new Client(new Uri(uriString));
            await Client.InitializeAsync(options);
            Client.AudioInputDevices.PropertyChanged += OnInputDevicesChanged;
            Client.AudioOutputDevices.PropertyChanged += OnOutputDevicesChanged;

            m_Initialized = true;
        }

        public async Task LoginAsync(LoginOptions loginOptions = null)
        {
            if (!ValidateAccessToken() || !ValidateIsLoggedOut())
            {
                return;
            }

            loginOptions = loginOptions ?? new LoginOptions();

            // If Auth is in use, use Auth's PlayerId.
            // If not, use a custom PlayerId override, if specified, or default to generating a GUID as a user's PlayerId.
            var playerId = IsAuthenticated
                ? PlayerId
                : string.IsNullOrEmpty(loginOptions.PlayerId) ? Guid.NewGuid().ToString() : loginOptions.PlayerId;

            m_LoginSession = Client.GetLoginSession(
                new AccountId(
                    Issuer,
                    playerId,
                    Domain,
                    loginOptions.DisplayName,
                    loginOptions.SpeechToTextLanguages.ToArray(),
                    string.IsNullOrEmpty(EnvironmentId) ? string.Empty : EnvironmentId));
            m_LoginSession.ParticipantPropertyFrequency = loginOptions.ParticipantUpdateFrequency;
            m_LoginSession.PropertyChanged += OnLoginSessionPropertyChanged;
            m_LoginSession.DirectedMessages.AfterItemAdded += OnDirectedMessageReceived;
            m_LoginSession.DirectedMessageEdited += OnDirectedMessageEdited;
            m_LoginSession.DirectedMessageDeleted += OnDirectedMessageDeleted;
#if AUTH_PACKAGE_PRESENT
            if (IsAuthenticated)
            {
                AuthenticationService.Instance.SignedOut += OnAuthenticationLost;
                AuthenticationService.Instance.Expired += OnAuthenticationLost;
                m_AuthCallbacksConnected = true;
            }
#endif
            await m_LoginSession.LoginAsync();
            await SetChannelTransmissionModeAsync(TransmissionMode.All);
            if (loginOptions.BlockedUserList.Count > 0)
            {
                foreach (string PlayerId in loginOptions.BlockedUserList)
                {
                    await BlockPlayerAsync(PlayerId);
                }
            }
        }

        public async Task LogoutAsync()
        {
            if (!IsLoggedIn)
            {
                return;
            }

            await LeaveAllChannelsAsync();
            await m_LoginSession.LogoutAsync();
        }

        public async Task SetChannelTransmissionModeAsync(TransmissionMode transmissionMode, string channelName = null)
        {
            if (transmissionMode == TransmissionMode.Single)
            {
                if (!ValidateIsInChannel(channelName))
                {
                    return;
                }

                var channelSession = m_LoginSession.ChannelSessions.FirstOrDefault(c => c.Key.Name == channelName);
                await m_LoginSession.SetTransmissionModeAsync(TransmissionMode.Single, channelSession.Key);
            }
            else
            {
                if (!ValidateIsLoggedIn())
                {
                    return;
                }

                await m_LoginSession.SetTransmissionModeAsync(transmissionMode);
            }
        }

        public void StartAudioInjection(string audioFilePath)
        {
            if (ValidateIsLoggedIn())
            {
                m_LoginSession.StartAudioInjection(audioFilePath);
            }
        }

        public void StopAudioInjection()
        {
            if (ValidateIsLoggedIn())
            {
                m_LoginSession.StopAudioInjection();
            }
        }

        public async Task SpeechToTextEnableTranscription(string channelName)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            await channelSession.SpeechToTextEnableTranscription(true);
        }

        public async Task SpeechToTextDisableTranscription(string channelName)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            await channelSession.SpeechToTextEnableTranscription(false);
        }

        public bool IsSpeechToTextEnabled(string channelName)
        {
            if (!ActiveChannels.Keys.Contains(channelName))
            {
                return false;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            return channelSession.IsSessionBeingTranscribed;
        }

        public void TextToSpeechSendMessage(string message, TextToSpeechMessageType messageType)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            var ttsMessage = new TTSMessage(message, messageType);
            m_LoginSession.TTS.Speak(ttsMessage);
        }

        public void TextToSpeechCancelAllMessages()
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            m_LoginSession.TTS.CancelAll();
        }

        public void TextToSpeechCancelMessages(TextToSpeechMessageType messageType)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            m_LoginSession.TTS.CancelDestination(messageType);
        }

        public async Task SendDirectTextMessageAsync(string playerId, string message, MessageOptions options)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            AccountId recipient = new AccountId(Issuer, playerId, Domain, null, null, EnvironmentId);
            await m_LoginSession.SendDirectedMessageAsync(recipient, message, options);
        }

        public async Task EditDirectTextMessageAsync(string messageId, string newMessage)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.EditDirectTextMessageAsync(messageId, newMessage);
        }

        public async Task DeleteDirectTextMessageAsync(string messageId)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.DeleteDirectTextMessageAsync(messageId);
        }

        public async Task SendChannelTextMessageAsync(string channelName, string message, MessageOptions options)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            await channelSession.SendChannelMessageAsync(message, options);
        }

        public async Task EditChannelTextMessageAsync(string channelName, string messageId, string newMessage)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            await channelSession.EditChannelTextMessageAsync(messageId, newMessage);
        }

        public async Task DeleteChannelTextMessageAsync(string channelName, string messageId)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            await channelSession.DeleteChannelTextMessageAsync(messageId);
        }

        public async Task<ReadOnlyCollection<VivoxMessage>> GetChannelTextMessageHistoryAsync(string channelName, int requestSize, ChatHistoryQueryOptions chatHistoryQueryOptions = null)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return null;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName);
            return await channelSession.GetChannelTextMessageHistoryAsync(requestSize, chatHistoryQueryOptions);
        }

        public async Task<ReadOnlyCollection<VivoxMessage>> GetDirectTextMessageHistoryAsync(string playerId = null, int requestSize = 10, ChatHistoryQueryOptions chatHistoryQueryOptions = null)
        {
            if (!ValidateIsLoggedIn())
            {
                return null;
            }

            var recipient = string.IsNullOrWhiteSpace(playerId) ? null : new AccountId(Issuer, playerId, Domain, null, null, EnvironmentId);
            return await m_LoginSession.GetDirectTextMessageHistoryAsync(recipient, requestSize, chatHistoryQueryOptions);
        }

        public async Task<ReadOnlyCollection<VivoxConversation>> GetConversationsAsync(ConversationQueryOptions queryOptions = null)
        {
            if (!ValidateIsLoggedIn())
            {
                return null;
            }

            return await m_LoginSession.GetConversationsAsync(queryOptions);
        }

        public async Task SetMessageAsReadAsync(VivoxMessage message, DateTime? seenAt = null)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.SetMessageAsReadAsync(message, seenAt);
        }

        /// <summary>
        /// Sets the token provider to an implementation provided by a developer.
        /// </summary>
        public void SetTokenProvider(IVivoxTokenProvider provider)
        {
            ExternalTokenProvider = provider;
        }

        public void MuteInputDevice()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            if (!Client.AudioInputDevices.Muted)
            {
                Client.AudioInputDevices.Muted = true;
                UserInputDeviceMuteStateChanged?.Invoke(Client.AudioInputDevices.Muted);
            }
        }

        public void UnmuteInputDevice()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            if (Client.AudioInputDevices.Muted)
            {
                Client.AudioInputDevices.Muted = false;
                UserInputDeviceMuteStateChanged?.Invoke(Client.AudioInputDevices.Muted);
            }
        }

        public void MuteOutputDevice()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            if (!Client.AudioOutputDevices.Muted)
            {
                Client.AudioOutputDevices.Muted = true;
            }
        }

        public void UnmuteOutputDevice()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            if (Client.AudioOutputDevices.Muted)
            {
                Client.AudioOutputDevices.Muted = false;
            }
        }

        public async Task BlockPlayerAsync(string playerId)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            var accountToBlock = new AccountId(Issuer, playerId, Domain, null, null, EnvironmentId);
            await m_LoginSession.BlockPlayerAsync(accountToBlock, true);
        }

        public async Task UnblockPlayerAsync(string playerId)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            var accountToUnblock = new AccountId(Issuer, playerId, Domain, null, null, EnvironmentId);
            await m_LoginSession.BlockPlayerAsync(accountToUnblock, false);
        }

        public async Task JoinGroupChannelAsync(string channelName, ChatCapability chatCapability, ChannelOptions channelOptions = null)
        {
            await JoinChannelAsync(channelName, chatCapability, ChannelType.NonPositional, channelOptions: channelOptions);
        }

        public async Task JoinPositionalChannelAsync(string channelName, ChatCapability chatCapability, Channel3DProperties positionalChannelProperties, ChannelOptions channelOptions = null)
        {
            await JoinChannelAsync(channelName, chatCapability, ChannelType.Positional, positionalChannelProperties, channelOptions);
        }

        public async Task JoinEchoChannelAsync(string channelName, ChatCapability chatCapability, ChannelOptions channelOptions = null)
        {
            await JoinChannelAsync(channelName, chatCapability, ChannelType.Echo, channelOptions: channelOptions);
        }

        /// <summary>
        /// By default we transmit to new channels automatically.
        /// If the user specifies that they don't want that behaviour by setting <see cref="LoginOptions.DisableAutomaticChannelTransmissionSwap"/> to true when logging in we will prevent the automatic transmission swap.
        /// Developers will need to manually switch transmission to other channels if automatic transmission to new channels is disabled.
        /// </summary>
        public async Task JoinChannelAsync(string channelName, ChatCapability chatCapability, ChannelType channelType, Channel3DProperties positionalChannelProperties = null, ChannelOptions channelOptions = null)
        {
            channelOptions = channelOptions ?? new ChannelOptions();
            if (!IsLoggedIn)
            {
                if (!ValidateIsInitialized())
                {
                    return;
                }
                await LoginAsync();
            }
            else
            {
                if (!ValidateIsLoggedIn())
                {
                    return;
                }
            }

            if (ActiveChannels.Keys.Contains(channelName))
            {
                VivoxLogger.LogException(new InvalidOperationException($"Unable to join channel \"{channelName}\" because there is already an active channel with the same name."));
                return;
            }

            ChannelId channel = new ChannelId(
                Issuer,
                channelName,
                Domain,
                channelType,
                positionalChannelProperties,
                EnvironmentId);
            IChannelSession channelSession = m_LoginSession.GetChannelSession(channel);
            SetChannelEventBindings(channelSession, true);
            await channelSession.ConnectAsync(chatCapability != ChatCapability.TextOnly, chatCapability != ChatCapability.AudioOnly, false);
        }

        public async Task LeaveAllChannelsAsync()
        {
            if (ActiveChannels.Count == 0)
            {
                return;
            }

            foreach (IChannelSession session in m_LoginSession.ChannelSessions.ToList())
            {
                await m_LoginSession.DeleteChannelSessionAsync(session.Key);
            }
        }

        public async Task LeaveChannelAsync(string channelName)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            await m_LoginSession.DeleteChannelSessionAsync(m_LoginSession.ChannelSessions.First(channel => channel.Channel.Name == channelName).Key);
        }

        public void TextToSpeechSetVoice(string voiceName)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            ITTSVoice expectedTTSVoice = m_LoginSession.TTS.AvailableVoices.FirstOrDefault(v => v.Name == voiceName);
            if (expectedTTSVoice == null)
            {
                VivoxLogger.LogException(new InvalidOperationException($"Unable to find a Text-To-Speech voice matching {voiceName} in the list of available voices."));
                return;
            }

            m_LoginSession.TTS.CurrentVoice = expectedTTSVoice;
        }

        public void Set3DPosition(GameObject participantObject, string channelName, bool allowPanning = true)
        {
            Transform transform = participantObject.transform;
            Set3DPosition(transform.position, transform.position, transform.forward, transform.up, channelName, allowPanning);
        }

        public void Set3DPosition(Vector3 speakerPos, Vector3 listenerPos, Vector3 listenerAtOrient, Vector3 listenerUpOrient, string channelName, bool allowPanning = true)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            IChannelSession channelSession = m_LoginSession.ChannelSessions.FirstOrDefault(channel => channel.Channel.Type == ChannelType.Positional && channel.Channel.Name == channelName);
            if (channelSession == null)
            {
                VivoxLogger.LogException(new InvalidOperationException($"A positional channel with name {channelName} could not be found."));
            }

            // If we find find the channel, we will allow updates only if it is fully connected.
            if (channelSession.ChannelState == ConnectionState.Connected)
            {
                channelSession.Set3DPosition(speakerPos, listenerPos, allowPanning ? listenerAtOrient : listenerUpOrient, listenerUpOrient);
            }
        }

        public void EnableAcousticEchoCancellation()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            Client.SetAudioEchoCancellation(true);
        }

        public void DisableAcousticEchoCancellation()
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            Client.SetAudioEchoCancellation(false);
        }

        public IosVoiceProcessingIOModes GetIosVoiceProcessingIOMode()
        {
            if (!ValidateIsInitialized())
            {
                return IosVoiceProcessingIOModes.ErrorOccurred;
            }

            return (IosVoiceProcessingIOModes)Client.IosVoiceProcessingIOMode;
        }

        public void SetIosVoiceProcessingIOMode(IosVoiceProcessingIOModes mode)
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            Client.SetIosVoiceProcessingIOMode((int)mode);
        }

        public async Task SetActiveInputDeviceAsync(VivoxInputDevice device)
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            await Client.AudioInputDevices.SetActiveDeviceAsync(device.m_parentDevice);
        }

        public async Task SetActiveOutputDeviceAsync(VivoxOutputDevice device)
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            await Client.AudioOutputDevices.SetActiveDeviceAsync(device.m_parentDevice);
        }

        public void SetInputDeviceVolume(int value)
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            Client.AudioInputDevices.VolumeAdjustment = Mathf.Clamp(value, -50, 50);
        }

        public void SetOutputDeviceVolume(int value)
        {
            if (!ValidateIsInitialized())
            {
                return;
            }

            Client.AudioOutputDevices.VolumeAdjustment = Mathf.Clamp(value, -50, 50);
        }

        public async Task SetChannelVolumeAsync(string channelName, int value)
        {
            if (!ValidateIsInChannel(channelName))
            {
                return;
            }

            var channel = m_LoginSession.ChannelSessions.First(kv => kv.Key.Name == channelName);
            await channel.SetVolumeAsync(Mathf.Clamp(value, -50, 50));
        }

        public async Task EnableAutoVoiceActivityDetectionAsync()
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.SetAutoVADAsync(true);
        }

        public async Task DisableAutoVoiceActivityDetectionAsync()
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.SetAutoVADAsync(false);
        }

        public async Task SetVoiceActivityDetectionPropertiesAsync(int hangover = 2000, int noiseFloor = 576, int sensitivity = 43)
        {
            if (!ValidateIsLoggedIn())
            {
                return;
            }

            await m_LoginSession.SetVADPropertiesAsync(hangover, Mathf.Clamp(noiseFloor, 0, 20000), Mathf.Clamp(sensitivity, 0, 100));
        }

        public async Task<bool> SetSafeVoiceConsentStatus(bool consentGiven)
        {
            if(!ValidateIsLoggedIn())
            {
                VivoxLogger.LogError("The Player must be logged in to consent to Vivox Safe Voice");
                return false;
            }
            if(!IsAuthenticated)
            {
                VivoxLogger.LogError("The Player must be authenticated through UAS in order to consent to Vivox Safe Voice");
                return false;
            }
            if(PlayerId != m_LoginSession.LoginSessionId.Name)
            {
                VivoxLogger.LogError("The Name provided to BeginLogin must match the UAS PlayerId in order to use Vivox Safe Voice");
                return false;
            }
            return await m_LoginSession.SetSafeVoiceConsentStatus(EnvironmentId, Application.cloudProjectId, PlayerId, AccessToken, consentGiven);
        }

        public async Task<bool> GetSafeVoiceConsentStatus()
        {
            if (!ValidateIsLoggedIn())
            {
                VivoxLogger.LogError("The Player must be logged in to get current consent to Vivox Safe Voice");
                return false;
            }
            if (!IsAuthenticated)
            {
                VivoxLogger.LogError("The Player must be authenticated through UAS in order to get current consent to Vivox Safe Voice");
                return false;
            }
            if (PlayerId != m_LoginSession.LoginSessionId.Name)
            {
                VivoxLogger.LogError("The Name provided to BeginLogin must match the UAS PlayerId in order to use Vivox Safe Voice");
                return false;
            }
            return await m_LoginSession.GetSafeVoiceConsentStatus(EnvironmentId, Application.cloudProjectId, PlayerId, AccessToken);
        }

        /// <summary>
        /// Manage the event bindings of a channel for events related to participant updates and the channel itself.
        /// </summary>
        /// <param name="channel">Channel to manage events bindings for.</param>
        /// <param name="doBind">true = bind, false = unbind.</param>
        public void SetChannelEventBindings(IChannelSession channel, bool doBind)
        {
            if (doBind)
            {
                channel.Participants.AfterKeyAdded += OnParticipantAdded;
                channel.Participants.BeforeKeyRemoved += OnParticipantRemoved;
                channel.PropertyChanged += OnChannelPropertyChanged;
                channel.TranscribedLog.AfterItemAdded += OnTranscribedMessageReceived;
                channel.MessageLog.AfterItemAdded += OnChannelMessageReceived;
                channel.MessageEdited += OnChannelMessageEdited;
                channel.MessageDeleted += OnChannelMessageDeleted;
            }
            else
            {
                channel.Participants.AfterKeyAdded -= OnParticipantAdded;
                channel.Participants.BeforeKeyRemoved -= OnParticipantRemoved;
                channel.PropertyChanged -= OnChannelPropertyChanged;
                channel.TranscribedLog.AfterItemAdded -= OnTranscribedMessageReceived;
                channel.MessageLog.AfterItemAdded -= OnChannelMessageReceived;
                channel.MessageEdited -= OnChannelMessageEdited;
                channel.MessageDeleted -= OnChannelMessageDeleted;
            }
        }

        public void OnLoginSessionPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var loginSession = (ILoginSession)sender;

            switch (propertyChangedEventArgs.PropertyName)
            {
                case "State":
                    HandleLoginStateChange(loginSession);
                    break;
                case "RecoveryState":
                    HandleRecoveryStateChange(loginSession);
                    break;
                default:
                    return;
            }
        }

        public void HandleLoginStateChange(ILoginSession loginSession)
        {
            LoginState newState = loginSession.State;
            switch (newState)
            {
                case LoginState.LoggedIn:
                {
                    LoggedIn?.Invoke();
                    break;
                }
                case LoginState.LoggedOut:
                {
                    m_ActiveChannels = new Dictionary<string, List<VivoxParticipant>>();
                    LoggedOut?.Invoke();
                    loginSession.PropertyChanged -= OnLoginSessionPropertyChanged;
                    loginSession.DirectedMessages.AfterItemAdded -= OnDirectedMessageReceived;
                    loginSession.DirectedMessageEdited -= OnDirectedMessageEdited;
                    loginSession.DirectedMessageDeleted -= OnDirectedMessageDeleted;
#if AUTH_PACKAGE_PRESENT
                    if (m_AuthCallbacksConnected)
                    {
                        AuthenticationService.Instance.SignedOut -= OnAuthenticationLost;
                        AuthenticationService.Instance.Expired -= OnAuthenticationLost;
                        m_AuthCallbacksConnected = false;
                    }
#endif
                    break;
                }
                default:
                    break;
            }
        }

        public void HandleRecoveryStateChange(ILoginSession loginSession)
        {
            ConnectionRecoveryState newState = loginSession.RecoveryState;
            switch (newState)
            {
                case ConnectionRecoveryState.Recovering:
                    ConnectionRecovering?.Invoke();
                    break;
                case ConnectionRecoveryState.Recovered:
                    ConnectionRecovered?.Invoke();
                    break;
                case ConnectionRecoveryState.FailedToRecover:
                    ConnectionFailedToRecover?.Invoke();
                    break;
            }
        }

        public void OnChannelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            var channelSession = (IChannelSession)sender;

            if (args.PropertyName == "ChannelState" && channelSession.ChannelState == ConnectionState.Disconnected)
            {
                SetChannelEventBindings(channelSession, false);
                m_ActiveChannels.Remove(channelSession.Channel.Name);
                ChannelLeft?.Invoke(channelSession.Channel.Name);
            }
            else if (args.PropertyName == "ChannelState" && channelSession.ChannelState == ConnectionState.Connected)
            {
                // Only add a channel as an active channel once it's fully connected and all participants are in.
                m_ActiveChannels.Add(channelSession.Channel.Name, new List<VivoxParticipant>());
                m_LastChannelJoinedUri = channelSession.Channel.ToString();
                ChannelJoined?.Invoke(channelSession.Channel.Name);

                foreach (var participant in channelSession.Participants)
                {
                    var newParticipant = new VivoxParticipant(this, participant);
                    m_ActiveChannels[channelSession.Channel.Name].Add(newParticipant);
                    ParticipantAddedToChannel?.Invoke(newParticipant);
                }
            }
        }

        private void OnTranscribedMessageReceived(object sender, QueueItemAddedEventArgs<ITranscribedMessage> transcribedMessage)
        {
            SpeechToTextMessageReceived?.Invoke(new VivoxMessage(transcribedMessage.Value));
        }

        public void OnChannelMessageReceived(object sender, QueueItemAddedEventArgs<IChannelTextMessage> textMessage)
        {
            IChannelTextMessage channelTextMessage = textMessage.Value;
            var message = new VivoxMessage(channelTextMessage);
            ChannelMessageReceived?.Invoke(message);
        }

        private void OnChannelMessageDeleted(object sender, VivoxMessage message)
        {
            ChannelMessageDeleted?.Invoke(message);
        }

        private void OnChannelMessageEdited(object sender, VivoxMessage message)
        {
            ChannelMessageEdited?.Invoke(message);
        }

        public void OnDirectedMessageReceived(object sender, QueueItemAddedEventArgs<IDirectedTextMessage> textMessage)
        {
            IDirectedTextMessage directedTextMessage = textMessage.Value;
            VivoxMessage message = new VivoxMessage(directedTextMessage);
            DirectedMessageReceived?.Invoke(message);
        }

        private void OnDirectedMessageDeleted(object sender, VivoxMessage message)
        {
            DirectedMessageDeleted?.Invoke(message);
        }

        private void OnDirectedMessageEdited(object sender, VivoxMessage message)
        {
            DirectedMessageEdited?.Invoke(message);
        }
        public void OnParticipantAdded(object sender, KeyEventArg<string> keyEventArg)
        {
            var source = (IReadOnlyDictionary<string, IParticipant>)sender;
            IParticipant addedParticipant = source[keyEventArg.Key];

            // After the local user is connected, let's allow firing events for any new users that join.
            if (addedParticipant.ParentChannelSession.ChannelState == ConnectionState.Connected)
            {
                var channelName = addedParticipant.ParentChannelSession.Channel.Name;
                // Don't try creating/adding any new participants if for some reason one matching the player ID and channel name exists already.
                if (m_ActiveChannels[channelName].FirstOrDefault(p => p.PlayerId == addedParticipant.Account.Name && p.ChannelName == channelName) != null)
                {
                    return;
                }

                var vivoxParticipant = new VivoxParticipant(this, addedParticipant);
                m_ActiveChannels[vivoxParticipant.ChannelName].Add(vivoxParticipant);
                ParticipantAddedToChannel?.Invoke(vivoxParticipant);
            }
        }

        public void OnParticipantRemoved(object sender, KeyEventArg<string> keyEventArg)
        {
            var source = (IReadOnlyDictionary<string, IParticipant>)sender;
            IParticipant participant = source[keyEventArg.Key];
            var relevantChannelName = participant.ParentChannelSession.Channel.Name;
            // The local player won't have the active channel anymore if they've left so don't try to remove participants it's gone.
            if (m_ActiveChannels.Keys.Contains(relevantChannelName))
            {
                var channelWithPartToRemove = m_ActiveChannels.First(kvp => kvp.Key == relevantChannelName);
                var participantToRemove = channelWithPartToRemove.Value.First(p => p.PlayerId == participant.Account.Name);
                channelWithPartToRemove.Value.Remove(participantToRemove);
                ParticipantRemovedFromChannel?.Invoke(participantToRemove);
            }
        }

        public void OnInputDevicesChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "AvailableDevices")
            {
                AvailableInputDevicesChanged?.Invoke();
            }
            else if (args.PropertyName == "EffectiveDevice")
            {
                EffectiveInputDeviceChanged?.Invoke();
            }
        }

        public void OnOutputDevicesChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "AvailableDevices")
            {
                AvailableOutputDevicesChanged?.Invoke();
            }
            else if (args.PropertyName == "EffectiveDevice")
            {
                EffectiveOutputDeviceChanged?.Invoke();
            }
        }

        private void OnAuthenticationLost()
        {
            if (IsLoggedIn)
            {
                VivoxLogger.LogWarning("The Authentication SDK has been signed out of. As a result, Vivox is logging out.");
                m_LoginSession.LogoutAsync();
            }
        }

        public ReadOnlyCollection<string> GetTransmittingChannels()
        {
            List<string> transmittingChannels = new List<string>();
            if (IsLoggedIn && ActiveChannels.Count > 0)
            {
                foreach (var transmittingChannel in m_LoginSession.TransmittingChannels)
                {
                    transmittingChannels.Add(transmittingChannel.Name);
                }
            }
            return transmittingChannels.AsReadOnly();
        }

        public ReadOnlyCollection<VivoxInputDevice> GetInputDevices()
        {
            var inputDevices = new List<VivoxInputDevice>();
            if (Client.Initialized)
            {
                foreach (var inputDevice in Client.AudioInputDevices.AvailableDevices)
                {
                    inputDevices.Add(new VivoxInputDevice(inputDevice));
                }
            }

            return inputDevices.AsReadOnly();
        }

        public ReadOnlyCollection<VivoxOutputDevice> GetOutputDevices()
        {
            var outputDevices = new List<VivoxOutputDevice>();
            if (Client.Initialized)
            {
                foreach (var outputDevice in Client.AudioOutputDevices.AvailableDevices)
                {
                    outputDevices.Add(new VivoxOutputDevice(outputDevice));
                }
            }

            return outputDevices.AsReadOnly();
        }

        public string GetChannelUriByName(string channelName)
        {
            // Once the channelId regex can parse a uri properly (channel name with a GUID) we can remove this code
            if (string.IsNullOrEmpty(channelName) || m_LoginSession == null)
            {
                return null;
            }

            // The substring is needed until we fix the ChannelId.Name having the Unity Environment (GUID) in it.
            var channelNameToLookup = channelName;
            if (channelNameToLookup.Contains("."))
            {
                channelNameToLookup = channelName.Substring(0, channelName.LastIndexOf("."));
            }

            return m_LoginSession.ChannelSessions
                .FirstOrDefault(c =>
                    String.Equals(c.Key.Name, channelNameToLookup, StringComparison.CurrentCultureIgnoreCase))?.Channel?.ToString();
        }

        public string GetParticipantUriByName(string participantName)
        {
            if (string.IsNullOrEmpty(participantName) || m_LoginSession == null)
            {
                return null;
            }

            string participantUriFound = null;
            foreach (var channelSession in m_LoginSession.ChannelSessions)
            {
                participantUriFound = channelSession.Participants.FirstOrDefault(p =>
                    p.Account.Name.ToLower() == participantName.ToLower() ||
                    p.Account.DisplayName.ToLower() == participantName)
                    ?.Account.ToString();
                if (!string.IsNullOrWhiteSpace(participantUriFound))
                {
                    // We found the participant so lets exit this foreach
                    break;
                }
            }
            return participantUriFound;
        }

        bool ValidateIsInitialized([CallerMemberName] string memberName = "")
        {
            if (!m_Initialized)
            {
                VivoxLogger.LogException(
                    new InvalidOperationException(
                        $"Unable to call {nameof(VivoxService)}.Instance.{memberName} because the Vivox Service is not initialized. " +
                        $"{nameof(VivoxService)}.Instance.{nameof(InitializeAsync)} must be called first."));

                return false;
            }
            return true;
        }

        bool ValidateIsLoggedIn([CallerMemberName] string memberName = "")
        {
            if (!ValidateIsInitialized(memberName))
            {
                return false;
            }

            if (!IsLoggedIn)
            {
                VivoxLogger.LogException(
                    new InvalidOperationException(
                        $"Unable to call {nameof(VivoxService)}.Instance.{memberName} because you have not signed into the Vivox Service. " +
                        $"{nameof(VivoxService)}.Instance.{nameof(LoginAsync)} must be called first."));
                return false;
            }

            return true;
        }

        bool ValidateIsLoggedOut([CallerMemberName] string memberName = "")
        {
            if (!ValidateIsInitialized(memberName))
            {
                return false;
            }

            if (IsLoggedIn)
            {
                VivoxLogger.LogException(
                    new InvalidOperationException(
                        $"Unable to call {nameof(VivoxService)}.Instance.{memberName} because you are already signed into the Vivox Service. " +
                        $"{nameof(VivoxService)}.Instance.{nameof(LogoutAsync)} must be called first."));
                return false;
            }

            return true;
        }

        bool ValidateAccessToken()
        {
            bool useLocalTokens = IsTestMode || !string.IsNullOrEmpty(Key);
            bool useServerSideTokens = ExternalTokenProvider != null || InternalTokenProvider != null;


            // TODO: vincent move this to login, but we might want to check it here if the provider is set?
            if (useLocalTokens)
            {
                VivoxLogger.LogWarning("We've detected a Vivox Secret Key being used in the project - we will generate Vivox Access Tokens locally using your Vivox Secret Key but this should only be used for testing!"
                    + "\nWhen you are successfully generating server-side Vivox Access Tokens, please remove the Vivox Key from the \"UnityServices.InitializeAsync(new InitializationOptions().SetVivoxCredentials(...))\" call."
                    + "\nIf Test Mode enabled in the Vivox configuration window (Edit > Project Settings > Services > Vivox) be sure to disable that as well.");
                Client.tokenGen.IssuerKey = Key;
            }
            else if (useServerSideTokens || IsAuthenticated)
            {
                if (!HaveVivoxCredentials)
                {
                    VivoxLogger.LogError("Vivox credentials are missing!"
                        + "\nPlease ensure a project is linked at Edit > Project Settings > Services and that you head to the Services > Vivox window to fetch your Vivox credentials."
                        + "If you wish to use credentials provided from outside of the Unity Dashboard, you can call \"UnityServices.InitializeAsync(new InitializationOptions().SetVivoxCredentials(...))\"");
                    return false;
                }

                Client.tokenGen = new VivoxJWTTokenGen(this);
            }
            else
            {
                VivoxLogger.LogError("Failed to initialize the SDK!"
                    + "\nIs a project linked at \"Edit > Project Settings > Services\"? Head to the \"Services > Vivox\" window to populate your Vivox credentials once a project is linked."
                    + "\nIf you wish to use credentials provided from outside of the Unity Dashboard, you can set them by calling \"UnityServices.InitializeAsync(new InitializationOptions().SetVivoxCredentials(...))\""
                    + "\nIf you're using the Authentication package, be sure to initialize it before initializing the Vivox SDK.");
                return false;
            }

            return true;
        }

        bool ValidateIsInChannel(string channelName = null, [CallerMemberName] string memberName = "")
        {
            if (!ValidateIsLoggedIn(memberName))
            {
                return false;
            }

            if (m_ActiveChannels.Count > 0)
            {
                if (!string.IsNullOrEmpty(channelName) && !m_ActiveChannels.ContainsKey(channelName))
                {
                    VivoxLogger.LogException(
                        new InvalidOperationException(
                            $"Unable to call {nameof(VivoxService)}.Instance.{memberName} because you are not currently in the specified target channel: {channelName} " +
                            $"{nameof(VivoxService)}.Instance.{nameof(JoinGroupChannelAsync)}|{nameof(JoinEchoChannelAsync)}|{nameof(JoinPositionalChannelAsync)} must be called first."));
                    return false;
                }
            }
            else
            {
                VivoxLogger.LogException(
                    new InvalidOperationException(
                        $"Unable to call {nameof(VivoxService)}.Instance.{memberName} because you are not currently in any channels." +
                        $"{nameof(VivoxService)}.Instance.{nameof(JoinGroupChannelAsync)}|{nameof(JoinEchoChannelAsync)}|{nameof(JoinPositionalChannelAsync)} must be called first."));
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Class used to override the token we pass into any Vivox requests.
    /// </summary>
    class VivoxJWTTokenGen : VxTokenGen
    {
        readonly VivoxServiceInternal m_VivoxService;
        internal DefaultApiClient m_MintApiClient;

        internal VivoxJWTTokenGen(VivoxServiceInternal vivoxService)
        {
            m_VivoxService = vivoxService;
            m_MintApiClient = new DefaultApiClient(new HttpClient(), m_VivoxService.AccessTokenComponent);
        }

        public override string GetToken(string issuer = null, TimeSpan? expiration = null, string targetUserUri = null, string action = null, string tokenKey = null, string channelUri = null, string fromUserUri = null)
        {
            return m_VivoxService.AccessToken;
        }

        /// <summary>
        /// Prioritizes leveraging a token provider provided by an external developer even if an internal package has provided one.
        /// The expectation is that we always defer to the customer but will handle token generation for them if they have not given us a token provider and an internal package has.
        /// If the operation we are performing is "login" then we'll use the Unity Authentication Service ("UAS") token for that but "login" is the only operation it can be used for.
        /// External and internal token providers are expected to be able to handle all other operations and provide valid Vivox tokens (VATs) as a result of their token provider implementation.
        /// </summary>
        public override async Task<string> GetTokenAsync(string issuer = null, TimeSpan? expiration = null, string targetUserUri = null, string action = null, string tokenKey = null, string channelUri = null, string fromUserUri = null)
        {
            if (m_VivoxService.ExternalTokenProvider != null)
            {
                return await m_VivoxService.ExternalTokenProvider?.GetTokenAsync(issuer, Helper.TimeSinceUnixEpochPlusDuration(expiration.Value), targetUserUri, action, channelUri, fromUserUri);
            }

            if (m_VivoxService.InternalTokenProvider != null && action != "login")
            {
                return await m_VivoxService.InternalTokenProvider?.GetTokenAsync(issuer, Helper.TimeSinceUnixEpochPlusDuration(expiration.Value), targetUserUri, action, channelUri, fromUserUri);
            }

            switch (action)
            {
                case "login":
                {
                    return await FetchLoginMintTokenAsync();
                }
                case "join":
                {
                    return await FetchChannelJoinMintTokenAsync(channelUri);
                }
                case "trxn":
                {
                    return m_VivoxService.AccessToken;
                }
                default:
                {
                    return m_VivoxService.AccessToken;
                }
            }
        }

        private async Task<string> FetchLoginMintTokenAsync()
        {
            var request = new ConnectTokenV1Request(environmentId: m_VivoxService.EnvironmentId,
                projectId: Application.cloudProjectId,
                playerId: m_VivoxService.PlayerId);

            string augmentedMintToken;
            try
            {
                Response<string> connectResponse = await m_MintApiClient.ConnectTokenV1Async(request);
                augmentedMintToken = connectResponse.Result;
            }
            catch (HttpException e)
            {
                throw new MintException(e);
            }

            // If we get back an empty token from Mint for some reason, let's try to resume operation as normal and simply provide the UAS Access Token.
            return string.IsNullOrEmpty(augmentedMintToken) ? m_VivoxService.AccessToken : augmentedMintToken;
        }

        private async Task<string> FetchChannelJoinMintTokenAsync(string channelUri)
        {
            var request = new JoinChannelV1Request(environmentId: m_VivoxService.EnvironmentId,
                projectId: Application.cloudProjectId,
                playerId: m_VivoxService.PlayerId,
                channelUri: channelUri);

            string augmentedMintToken;
            try
            {
                Response<string> joinResponse = await m_MintApiClient.JoinChannelV1Async(request);
                augmentedMintToken = joinResponse.Result;
            }
            catch (HttpException e)
            {
                throw new MintException(e);
            }

            // If we get back an empty token from Mint for some reason, let's try to resume operation as normal and simply provide the UAS Access Token.
            return string.IsNullOrEmpty(augmentedMintToken) ? m_VivoxService.AccessToken : augmentedMintToken;
        }
    }
}
