using System.Threading.Tasks;

namespace Unity.Services.Vivox
{
    ///<summary>
    /// An Output AudioDevice on the device connecting to Vivox.
    /// Can be a physical audio device, like a set of headphones,
    /// or an abstraction, like the device's default communication audio device.
    ///</summary>
    public sealed class VivoxOutputDevice : IVivoxAudioDevice
    {
        internal IAudioDevice m_parentDevice;

        /// <summary>
        /// The name of the device
        /// </summary>
        public string DeviceName { get => m_parentDevice.Name; }
        /// <summary>
        /// The ID of the device
        /// </summary>
        public string DeviceID { get => m_parentDevice.Key; }

        internal VivoxOutputDevice(IAudioDevice parentDevice)
        {
            m_parentDevice = parentDevice;
        }

        ///<summary>
        /// Set this Input Device to be the active Vivox Input Device
        ///</summary>
        /// <returns> A task for the operation </returns>
        public async Task SetActiveDeviceAsync()
        {
            await VivoxService.Instance.SetActiveOutputDeviceAsync(this);
        }
    }
}
