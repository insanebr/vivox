//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Unity.Services.Vivox {

internal class vx_before_recv_audio_mixed_participant_data_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_before_recv_audio_mixed_participant_data_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_before_recv_audio_mixed_participant_data_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_before_recv_audio_mixed_participant_data_t obj) {
    if (obj != null) {
      if (!obj.swigCMemOwn)
        throw new global::System.ApplicationException("Cannot release ownership as memory is not owned");
      global::System.Runtime.InteropServices.HandleRef ptr = obj.swigCPtr;
      obj.swigCMemOwn = false;
      obj.Dispose();
      return ptr;
    } else {
      return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }
  }

  ~vx_before_recv_audio_mixed_participant_data_t() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vx_before_recv_audio_mixed_participant_data_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public string participant_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_participant_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_participant_uri_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_short pcm_frames {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_pcm_frames_set(swigCPtr, SWIGTYPE_p_short.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_pcm_frames_get(swigCPtr);
      SWIGTYPE_p_short ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_short(cPtr, false);
      return ret;
    } 
  }

  public int pcm_frame_count {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_pcm_frame_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_pcm_frame_count_get(swigCPtr);
      return ret;
    } 
  }

  public int audio_frame_rate {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_audio_frame_rate_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_audio_frame_rate_get(swigCPtr);
      return ret;
    } 
  }

  public int channels_per_frame {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_channels_per_frame_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_channels_per_frame_get(swigCPtr);
      return ret;
    } 
  }

  public string session_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_session_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_before_recv_audio_mixed_participant_data_t_session_uri_get(swigCPtr);
      return ret;
    } 
  }

  public vx_before_recv_audio_mixed_participant_data_t() : this(VivoxCoreInstancePINVOKE.new_vx_before_recv_audio_mixed_participant_data_t(), true) {
  }

}

}