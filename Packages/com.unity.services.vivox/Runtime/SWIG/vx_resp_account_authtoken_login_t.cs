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

internal class vx_resp_account_authtoken_login_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_resp_account_authtoken_login_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_resp_account_authtoken_login_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_resp_account_authtoken_login_t obj) {
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

  ~vx_resp_account_authtoken_login_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_resp_account_authtoken_login_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_resp_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_base__set(swigCPtr, vx_resp_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_base__get(swigCPtr);
      vx_resp_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_resp_base_t(cPtr, false);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public int account_id {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_account_id_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_account_id_get(swigCPtr);
      return ret;
    } 
  }

  public string user_name {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_user_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_user_name_get(swigCPtr);
      return ret;
    } 
  }

  public string display_name {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_display_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_display_name_get(swigCPtr);
      return ret;
    } 
  }

  public string uri {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_uri_get(swigCPtr);
      return ret;
    } 
  }

  public int num_aliases {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_num_aliases_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_num_aliases_get(swigCPtr);
      return ret;
    } 
  }

  public string buddy_list_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_buddy_list_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_buddy_list_uri_get(swigCPtr);
      return ret;
    } 
  }

  public string encoded_uri_with_tag {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_encoded_uri_with_tag_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_account_authtoken_login_t_encoded_uri_with_tag_get(swigCPtr);
      return ret;
    } 
  }

  public vx_resp_account_authtoken_login_t() : this(VivoxCoreInstancePINVOKE.new_vx_resp_account_authtoken_login_t(), true) {
  }

}

}
