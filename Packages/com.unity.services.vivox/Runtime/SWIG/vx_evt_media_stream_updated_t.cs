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

internal class vx_evt_media_stream_updated_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_evt_media_stream_updated_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_evt_media_stream_updated_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_evt_media_stream_updated_t obj) {
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

  ~vx_evt_media_stream_updated_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_evt_media_stream_updated_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_evt_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_base__set(swigCPtr, vx_evt_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_base__get(swigCPtr);
      vx_evt_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_evt_base_t(cPtr, false);
      return ret;
    } 
  }

  public string sessiongroup_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_sessiongroup_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_sessiongroup_handle_get(swigCPtr);
      return ret;
    } 
  }

  public string session_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_session_handle_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_session_handle_get(swigCPtr);
      return ret;
    } 
  }

  public int status_code {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_status_code_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_status_code_get(swigCPtr);
      return ret;
    } 
  }

  public string status_string {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_status_string_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_status_string_get(swigCPtr);
      return ret;
    } 
  }

  public vx_session_media_state state {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_state_set(swigCPtr, (int)value);
    } 
    get {
      vx_session_media_state ret = (vx_session_media_state)VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_state_get(swigCPtr);
      return ret;
    } 
  }

  public int incoming {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_incoming_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_incoming_get(swigCPtr);
      return ret;
    } 
  }

  public string durable_media_id {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_durable_media_id_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_durable_media_id_get(swigCPtr);
      return ret;
    } 
  }

  public string media_probe_server {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_media_probe_server_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_media_probe_server_get(swigCPtr);
      return ret;
    } 
  }

  public vx_call_stats_t call_stats {
    set {
      VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_call_stats_set(swigCPtr, vx_call_stats_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_evt_media_stream_updated_t_call_stats_get(swigCPtr);
      vx_call_stats_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_call_stats_t(cPtr, false);
      return ret;
    } 
  }

  public vx_evt_media_stream_updated_t() : this(VivoxCoreInstancePINVOKE.new_vx_evt_media_stream_updated_t(), true) {
  }

}

}
