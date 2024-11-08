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

internal class vx_req_sessiongroup_create_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_req_sessiongroup_create_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_req_sessiongroup_create_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_req_sessiongroup_create_t obj) {
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

  ~vx_req_sessiongroup_create_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_req_sessiongroup_create_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

        public static implicit operator vx_req_base_t(vx_req_sessiongroup_create_t t) {
            return t.base_;
        }
        
  public vx_req_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_base__set(swigCPtr, vx_req_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_base__get(swigCPtr);
      vx_req_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_req_base_t(cPtr, false);
      return ret;
    } 
  }

  public string account_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_account_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_account_handle_get(swigCPtr);
      return ret;
    } 
  }

  public vx_sessiongroup_type type {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_type_set(swigCPtr, (int)value);
    } 
    get {
      vx_sessiongroup_type ret = (vx_sessiongroup_type)VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_type_get(swigCPtr);
      return ret;
    } 
  }

  public int loop_mode_duration_seconds {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_loop_mode_duration_seconds_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_loop_mode_duration_seconds_get(swigCPtr);
      return ret;
    } 
  }

  public string capture_device_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_capture_device_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_capture_device_id_get(swigCPtr);
      return ret;
    } 
  }

  public string render_device_id {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_render_device_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_render_device_id_get(swigCPtr);
      return ret;
    } 
  }

  public string alias_username {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_alias_username_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_alias_username_get(swigCPtr);
      return ret;
    } 
  }

  public string sessiongroup_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_sessiongroup_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_req_sessiongroup_create_t_sessiongroup_handle_get(swigCPtr);
      return ret;
    } 
  }

  public vx_req_sessiongroup_create_t() : this(VivoxCoreInstancePINVOKE.new_vx_req_sessiongroup_create_t(), true) {
        if (!VxClient.Instance.Started) {
            throw new System.InvalidOperationException("Vivox SDK is not initialized");
        }
    }
        
}

}
