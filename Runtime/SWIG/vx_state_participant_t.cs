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

internal class vx_state_participant_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_state_participant_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_state_participant_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_state_participant_t obj) {
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

  ~vx_state_participant_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_state_participant_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public string uri {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_uri_get(swigCPtr);
      return ret;
    } 
  }

  public string display_name {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_display_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_display_name_get(swigCPtr);
      return ret;
    } 
  }

  public int is_audio_enabled {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_enabled_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_enabled_get(swigCPtr);
      return ret;
    } 
  }

  public int is_text_enabled {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_enabled_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_enabled_get(swigCPtr);
      return ret;
    } 
  }

  public int is_audio_muted_for_me {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_muted_for_me_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_muted_for_me_get(swigCPtr);
      return ret;
    } 
  }

  public int is_text_muted_for_me {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_muted_for_me_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_muted_for_me_get(swigCPtr);
      return ret;
    } 
  }

  public int is_audio_moderator_muted {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_moderator_muted_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_audio_moderator_muted_get(swigCPtr);
      return ret;
    } 
  }

  public int is_text_moderator_muted {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_moderator_muted_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_text_moderator_muted_get(swigCPtr);
      return ret;
    } 
  }

  public int is_hand_raised {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_hand_raised_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_hand_raised_get(swigCPtr);
      return ret;
    } 
  }

  public int is_typing {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_typing_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_typing_get(swigCPtr);
      return ret;
    } 
  }

  public int is_speaking {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_speaking_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_speaking_get(swigCPtr);
      return ret;
    } 
  }

  public int volume {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_volume_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_volume_get(swigCPtr);
      return ret;
    } 
  }

  public double energy {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_energy_set(swigCPtr, value);
    } 
    get {
      double ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_energy_get(swigCPtr);
      return ret;
    } 
  }

  public vx_participant_type type {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_type_set(swigCPtr, (int)value);
    } 
    get {
      vx_participant_type ret = (vx_participant_type)VivoxCoreInstancePINVOKE.vx_state_participant_t_type_get(swigCPtr);
      return ret;
    } 
  }

  public int is_anonymous_login {
    set {
      VivoxCoreInstancePINVOKE.vx_state_participant_t_is_anonymous_login_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_participant_t_is_anonymous_login_get(swigCPtr);
      return ret;
    } 
  }

  public vx_state_participant_t() : this(VivoxCoreInstancePINVOKE.new_vx_state_participant_t(), true) {
  }

}

}
