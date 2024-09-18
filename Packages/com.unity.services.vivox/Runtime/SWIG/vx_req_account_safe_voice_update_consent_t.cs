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

internal class vx_req_account_safe_voice_update_consent_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_account_safe_voice_update_consent_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_account_safe_voice_update_consent_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_req_account_safe_voice_update_consent_t obj) {
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

  ~vx_req_account_safe_voice_update_consent_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_req_account_safe_voice_update_consent_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

        public static implicit operator vx_req_base_t(vx_req_account_safe_voice_update_consent_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string unity_environment_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_environment_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_environment_id_get(swigCPtr);
      return ret;
    } 
  }

  public string unity_authentication_token {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_authentication_token_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_authentication_token_get(swigCPtr);
      return ret;
    } 
  }

  public string unity_project_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_project_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_unity_project_id_get(swigCPtr);
      return ret;
    } 
  }

  public string player_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_player_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_player_id_get(swigCPtr);
      return ret;
    } 
  }

  public bool consent_status {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_consent_status_set(swigCPtr, value);
    } 
    get {
      bool ret = VivoxCoreInstancePINVOKE.vx_req_account_safe_voice_update_consent_t_consent_status_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_account_safe_voice_update_consent_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_account_safe_voice_update_consent_t(), true) {
        if (!VxClient.Instance.Started) {
            throw new System.InvalidOperationException("Vivox SDK is not initialized");
        }
    }
        
}

}
