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

internal class vx_resp_account_get_conversations_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_resp_account_get_conversations_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_resp_account_get_conversations_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_resp_account_get_conversations_t obj) {
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

  ~vx_resp_account_get_conversations_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_resp_account_get_conversations_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_resp_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_base__set(swigCPtr, vx_resp_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_base__get(swigCPtr);
      vx_resp_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_resp_base_t(cPtr, false);
      return ret;
    } 
  }

  public int conversations_size {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_conversations_size_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_conversations_size_get(swigCPtr);
      return ret;
    } 
  }

  public int next_cursor {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_next_cursor_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_next_cursor_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_vx_conversation conversations {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_conversations_set(swigCPtr, SWIGTYPE_p_p_vx_conversation.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_conversations_get(swigCPtr);
      SWIGTYPE_p_p_vx_conversation ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_vx_conversation(cPtr, false);
      return ret;
    } 
  }

  public vx_conversation_t GetConversation(int index) {
    vx_conversation_t ret = new vx_conversation_t(VivoxCoreInstancePINVOKE.vx_resp_account_get_conversations_t_GetConversation(swigCPtr, index), false);
    return ret;
  }

  public vx_resp_account_get_conversations_t() : this(VivoxCoreInstancePINVOKE.new_vx_resp_account_get_conversations_t(), true) {
  }

}

}