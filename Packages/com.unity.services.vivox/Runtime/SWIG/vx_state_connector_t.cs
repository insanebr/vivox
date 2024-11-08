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

internal class vx_state_connector_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_state_connector_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_state_connector_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_state_connector_t obj) {
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

  ~vx_state_connector_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_state_connector_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public string connector_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_connector_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_connector_handle_get(swigCPtr);
      return ret;
    } 
  }

  public int state_accounts_count {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_state_accounts_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_state_accounts_count_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_vx_state_account state_accounts {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_state_accounts_set(swigCPtr, SWIGTYPE_p_p_vx_state_account.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_state_connector_t_state_accounts_get(swigCPtr);
      SWIGTYPE_p_p_vx_state_account ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_vx_state_account(cPtr, false);
      return ret;
    } 
  }

  public int mic_vol {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_mic_vol_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_mic_vol_get(swigCPtr);
      return ret;
    } 
  }

  public int mic_mute {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_mic_mute_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_mic_mute_get(swigCPtr);
      return ret;
    } 
  }

  public int speaker_vol {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_speaker_vol_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_speaker_vol_get(swigCPtr);
      return ret;
    } 
  }

  public int speaker_mute {
    set {
      VivoxCoreInstancePINVOKE.vx_state_connector_t_speaker_mute_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_state_connector_t_speaker_mute_get(swigCPtr);
      return ret;
    } 
  }

  public vx_state_connector_t() : this(VivoxCoreInstancePINVOKE.new_vx_state_connector_t(), true) {
  }

}

}
