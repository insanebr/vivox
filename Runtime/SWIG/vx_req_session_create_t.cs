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

internal class vx_req_session_create_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_session_create_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_session_create_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_req_session_create_t obj) {
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

  ~vx_req_session_create_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_req_session_create_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

        public static implicit operator vx_req_base_t(vx_req_session_create_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_session_create_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string name {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_name_get(swigCPtr);
      return ret;
    } 
  }

  public string uri {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_uri_get(swigCPtr);
      return ret;
    } 
  }

  public string password {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_password_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_password_get(swigCPtr);
      return ret;
    } 
  }

  public int connect_audio {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_connect_audio_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_connect_audio_get(swigCPtr);
      return ret;
    } 
  }

  public int join_audio {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_join_audio_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_join_audio_get(swigCPtr);
      return ret;
    } 
  }

  public int join_text {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_join_text_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_join_text_get(swigCPtr);
      return ret;
    } 
  }

  public vx_password_hash_algorithm_t password_hash_algorithm {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_password_hash_algorithm_set(swigCPtr, (int)value);
    } 
    get {
      vx_password_hash_algorithm_t ret = (vx_password_hash_algorithm_t)VivoxCoreInstancePINVOKE.vx_req_session_create_t_password_hash_algorithm_get(swigCPtr);
      return ret;
    } 
  }

  public int connect_text {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_connect_text_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_connect_text_get(swigCPtr);
      return ret;
    } 
  }

  public int session_font_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_session_font_id_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_session_font_id_get(swigCPtr);
      return ret;
    } 
  }

  public int jitter_compensation {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_jitter_compensation_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_jitter_compensation_get(swigCPtr);
      return ret;
    } 
  }

  public string alias_username {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_alias_username_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_alias_username_get(swigCPtr);
      return ret;
    } 
  }

  public string sessiongroup_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_sessiongroup_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_sessiongroup_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string session_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_session_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_session_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string access_token {
    set {
      VivoxCoreInstancePINVOKE.vx_req_session_create_t_access_token_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_session_create_t_access_token_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_session_create_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_session_create_t(), true) {
        if (!VxClient.Instance.Started) {
            throw new System.InvalidOperationException("Vivox SDK is not initialized");
        }
    }
        
}

}