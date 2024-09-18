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

internal class vx_req_account_anonymous_login_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_account_anonymous_login_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_account_anonymous_login_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_req_account_anonymous_login_t obj) {
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

  ~vx_req_account_anonymous_login_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_req_account_anonymous_login_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

        public static implicit operator vx_req_base_t(vx_req_account_anonymous_login_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string connector_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_connector_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_connector_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string displayname {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_displayname_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_displayname_get(swigCPtr);
      return ret;
    } 
  }

  public int participant_property_frequency {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_participant_property_frequency_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_participant_property_frequency_get(swigCPtr);
      return ret;
    } 
  }

  public int enable_buddies_and_presence {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_enable_buddies_and_presence_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_enable_buddies_and_presence_get(swigCPtr);
      return ret;
    } 
  }

  public vx_buddy_management_mode buddy_management_mode {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_buddy_management_mode_set(swigCPtr, (int)value);
    } 
    get {
      vx_buddy_management_mode ret = (vx_buddy_management_mode)VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_buddy_management_mode_get(swigCPtr);
      return ret;
    } 
  }

  public int autopost_crash_dumps {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_autopost_crash_dumps_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_autopost_crash_dumps_get(swigCPtr);
      return ret;
    } 
  }

  public string acct_mgmt_server {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_acct_mgmt_server_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_acct_mgmt_server_get(swigCPtr);
      return ret;
    } 
  }

  public string application_token {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_application_token_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_application_token_get(swigCPtr);
      return ret;
    } 
  }

  public string application_override {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_application_override_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_application_override_get(swigCPtr);
      return ret;
    } 
  }

  public string client_ip_override {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_client_ip_override_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_client_ip_override_get(swigCPtr);
      return ret;
    } 
  }

  public int enable_presence_persistence {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_enable_presence_persistence_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_enable_presence_persistence_get(swigCPtr);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string acct_name {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_acct_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_acct_name_get(swigCPtr);
      return ret;
    } 
  }

  public string access_token {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_access_token_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_access_token_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_char initial_buddy_uris {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_buddy_uris_set(swigCPtr, SWIGTYPE_p_p_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_buddy_uris_get(swigCPtr);
      SWIGTYPE_p_p_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_char(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_char initial_blocked_uris {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_blocked_uris_set(swigCPtr, SWIGTYPE_p_p_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_blocked_uris_get(swigCPtr);
      SWIGTYPE_p_p_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_char(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_char initial_blocked_uris_presence_only {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_blocked_uris_presence_only_set(swigCPtr, SWIGTYPE_p_p_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_blocked_uris_presence_only_get(swigCPtr);
      SWIGTYPE_p_p_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_char(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_char initial_allowed_uris {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_allowed_uris_set(swigCPtr, SWIGTYPE_p_p_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_initial_allowed_uris_get(swigCPtr);
      SWIGTYPE_p_p_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_char(cPtr, false);
      return ret;
    } 
  }

  public string languages {
    set {
      VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_languages_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_account_anonymous_login_t_languages_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_account_anonymous_login_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_account_anonymous_login_t(), true) {
        if (!VxClient.Instance.Started) {
            throw new System.InvalidOperationException("Vivox SDK is not initialized");
        }
    }
        
}

}