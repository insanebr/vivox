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

internal class vx_evt_voice_service_connection_state_changed_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_evt_voice_service_connection_state_changed_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_evt_voice_service_connection_state_changed_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_evt_voice_service_connection_state_changed_t obj) {
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

  ~vx_evt_voice_service_connection_state_changed_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_evt_voice_service_connection_state_changed_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_evt_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_base__set(swigCPtr, vx_evt_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_base__get(swigCPtr);
      vx_evt_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_evt_base_t(cPtr, false);
      return ret;
    } 
  }

  public int connected {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_connected_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_connected_get(swigCPtr);
      return ret;
    } 
  }

  public string platform {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_platform_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_platform_get(swigCPtr);
      return ret;
    } 
  }

  public string version {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_version_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_version_get(swigCPtr);
      return ret;
    } 
  }

  public string data_directory {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_data_directory_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_data_directory_get(swigCPtr);
      return ret;
    } 
  }

  public int network_test_run {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_run_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_run_get(swigCPtr);
      return ret;
    } 
  }

  public int network_test_completed {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_completed_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_completed_get(swigCPtr);
      return ret;
    } 
  }

  public int network_test_state {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_state_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_test_state_get(swigCPtr);
      return ret;
    } 
  }

  public int network_is_down {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_is_down_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_voice_service_connection_state_changed_t_network_is_down_get(swigCPtr);
      return ret;
    } 
  }

  public vx_evt_voice_service_connection_state_changed_t() : this(VivoxCoreInstancePINVOKE.new_vx_evt_voice_service_connection_state_changed_t(), true) {
  }

}

}
