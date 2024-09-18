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

internal class vx_message_base_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_message_base_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_message_base_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_message_base_t obj) {
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

        ~vx_message_base_t() {
            Dispose();
        }
    
  public virtual void Dispose() {
        if(VivoxCoreInstance.vx_initialized){
            lock(this) {
            if (swigCPtr.Handle != global::System.IntPtr.Zero) {
                if (swigCMemOwn) {
                swigCMemOwn = false;
                VivoxCoreInstancePINVOKE.delete_vx_message_base_t(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            global::System.GC.SuppressFinalize(this);
            }
        }
    }

        public static implicit operator vx_resp_base_t(vx_message_base_t t) {
            return t.as_resp_base();
        }
        public static implicit operator vx_evt_base_t(vx_message_base_t t) {
            return t.as_evt_base();
        }
    
  public vx_message_type type {
    set {
      VivoxCoreInstancePINVOKE.vx_message_base_t_type_set(swigCPtr, (int)value);
    } 
    get {
      vx_message_type ret = (vx_message_type)VivoxCoreInstancePINVOKE.vx_message_base_t_type_get(swigCPtr);
      return ret;
    } 
  }

  public uint sdk_handle {
    set {
      VivoxCoreInstancePINVOKE.vx_message_base_t_sdk_handle_set(swigCPtr, value);
    } 
    get {
      uint ret = VivoxCoreInstancePINVOKE.vx_message_base_t_sdk_handle_get(swigCPtr);
      return ret;
    } 
  }

  public ulong create_time_ms {
    set {
      VivoxCoreInstancePINVOKE.vx_message_base_t_create_time_ms_set(swigCPtr, value);
    } 
    get {
      ulong ret = VivoxCoreInstancePINVOKE.vx_message_base_t_create_time_ms_get(swigCPtr);
      return ret;
    } 
  }

  public ulong last_step_ms {
    set {
      VivoxCoreInstancePINVOKE.vx_message_base_t_last_step_ms_set(swigCPtr, value);
    } 
    get {
      ulong ret = VivoxCoreInstancePINVOKE.vx_message_base_t_last_step_ms_get(swigCPtr);
      return ret;
    } 
  }

  public vx_resp_base_t as_resp_base() {
    global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_message_base_t_as_resp_base(swigCPtr);
    vx_resp_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_resp_base_t(cPtr, false);
    return ret;
  }

  public vx_evt_base_t as_evt_base() {
    global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_message_base_t_as_evt_base(swigCPtr);
    vx_evt_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_evt_base_t(cPtr, false);
    return ret;
  }

  public vx_message_base_t() : this(VivoxCoreInstancePINVOKE.new_vx_message_base_t(), true) {
  }

}

}
