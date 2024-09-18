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

internal class vx_evt_participant_added_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_evt_participant_added_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_evt_participant_added_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_evt_participant_added_t obj) {
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

  ~vx_evt_participant_added_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_evt_participant_added_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_evt_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_base__set(swigCPtr, vx_evt_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_base__get(swigCPtr);
      vx_evt_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_evt_base_t(cPtr, false);
      return ret;
    } 
  }

  public string sessiongroup_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_sessiongroup_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_sessiongroup_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string session_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_session_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_session_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string participant_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_participant_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_participant_uri_get(swigCPtr);
      return ret;
    } 
  }

  public string account_name {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_account_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_account_name_get(swigCPtr);
      return ret;
    } 
  }

  public string display_name {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_display_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_display_name_get(swigCPtr);
      return ret;
    } 
  }

  public int participant_type {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_participant_type_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_participant_type_get(swigCPtr);
      return ret;
    } 
  }

  public string application {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_application_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_application_get(swigCPtr);
      return ret;
    } 
  }

  public int is_anonymous_login {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_is_anonymous_login_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_is_anonymous_login_get(swigCPtr);
      return ret;
    } 
  }

  public string displayname {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_displayname_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_displayname_get(swigCPtr);
      return ret;
    } 
  }

  public string alias_username {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_alias_username_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_alias_username_get(swigCPtr);
      return ret;
    } 
  }

  public string encoded_uri_with_tag {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_encoded_uri_with_tag_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_encoded_uri_with_tag_get(swigCPtr);
      return ret;
    } 
  }

  public int is_current_user {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_is_current_user_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_participant_added_t_is_current_user_get(swigCPtr);
      return ret;
    } 
  }

  public vx_evt_participant_added_t() : this(VivoxCoreInstancePINVOKE.new_vx_evt_participant_added_t(), true) {
  }

}

}
