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

internal class vx_resp_aux_connectivity_info_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_resp_aux_connectivity_info_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_resp_aux_connectivity_info_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_resp_aux_connectivity_info_t obj) {
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

  ~vx_resp_aux_connectivity_info_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_resp_aux_connectivity_info_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public vx_resp_base_t base_ {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_base__set(swigCPtr, vx_resp_base_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_base__get(swigCPtr);
      vx_resp_base_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new vx_resp_base_t(cPtr, false);
      return ret;
    } 
  }

  public int count {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_count_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_vx_connectivity_test_result test_results {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_test_results_set(swigCPtr, SWIGTYPE_p_p_vx_connectivity_test_result.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_test_results_get(swigCPtr);
      SWIGTYPE_p_p_vx_connectivity_test_result ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_p_vx_connectivity_test_result(cPtr, false);
      return ret;
    } 
  }

  public string well_known_ip {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_well_known_ip_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_well_known_ip_get(swigCPtr);
      return ret;
    } 
  }

  public string stun_server {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_stun_server_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_stun_server_get(swigCPtr);
      return ret;
    } 
  }

  public string echo_server {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_echo_server_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_echo_server_get(swigCPtr);
      return ret;
    } 
  }

  public int echo_port {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_echo_port_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_echo_port_get(swigCPtr);
      return ret;
    } 
  }

  public int timeout {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_timeout_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_timeout_get(swigCPtr);
      return ret;
    } 
  }

  public int first_sip_port {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_first_sip_port_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_first_sip_port_get(swigCPtr);
      return ret;
    } 
  }

  public int second_sip_port {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_second_sip_port_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_second_sip_port_get(swigCPtr);
      return ret;
    } 
  }

  public int rtp_port {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_rtp_port_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_rtp_port_get(swigCPtr);
      return ret;
    } 
  }

  public int rtcp_port {
    set {
      VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_rtcp_port_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_resp_aux_connectivity_info_t_rtcp_port_get(swigCPtr);
      return ret;
    } 
  }

  public vx_resp_aux_connectivity_info_t() : this(VivoxCoreInstancePINVOKE.new_vx_resp_aux_connectivity_info_t(), true) {
  }

}

}
