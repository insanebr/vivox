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

internal class vx_channel_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vx_channel_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vx_channel_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(vx_channel_t obj) {
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

  ~vx_channel_t() {
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
          VivoxCoreInstancePINVOKE.delete_vx_channel_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public string channel_name {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_channel_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_channel_name_get(swigCPtr);
      return ret;
    } 
  }

  public string channel_desc {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_channel_desc_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_channel_desc_get(swigCPtr);
      return ret;
    } 
  }

  public string host {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_host_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_host_get(swigCPtr);
      return ret;
    } 
  }

  public int channel_id {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_channel_id_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_channel_id_get(swigCPtr);
      return ret;
    } 
  }

  public int limit {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_limit_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_limit_get(swigCPtr);
      return ret;
    } 
  }

  public int capacity {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_capacity_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_capacity_get(swigCPtr);
      return ret;
    } 
  }

  public string modified {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_modified_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_modified_get(swigCPtr);
      return ret;
    } 
  }

  public string owner {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_owner_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_owner_get(swigCPtr);
      return ret;
    } 
  }

  public string owner_user_name {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_owner_user_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_owner_user_name_get(swigCPtr);
      return ret;
    } 
  }

  public int is_persistent {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_is_persistent_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_is_persistent_get(swigCPtr);
      return ret;
    } 
  }

  public int is_protected {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_is_protected_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_is_protected_get(swigCPtr);
      return ret;
    } 
  }

  public int size {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_size_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_size_get(swigCPtr);
      return ret;
    } 
  }

  public int type {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_type_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_type_get(swigCPtr);
      return ret;
    } 
  }

  public vx_channel_mode mode {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_mode_set(swigCPtr, (int)value);
    } 
    get {
      vx_channel_mode ret = (vx_channel_mode)VivoxCoreInstancePINVOKE.vx_channel_t_mode_get(swigCPtr);
      return ret;
    } 
  }

  public string channel_uri {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_channel_uri_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_channel_uri_get(swigCPtr);
      return ret;
    } 
  }

  public int max_range {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_max_range_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_max_range_get(swigCPtr);
      return ret;
    } 
  }

  public int clamping_dist {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_clamping_dist_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_clamping_dist_get(swigCPtr);
      return ret;
    } 
  }

  public double roll_off {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_roll_off_set(swigCPtr, value);
    } 
    get {
      double ret = VivoxCoreInstancePINVOKE.vx_channel_t_roll_off_get(swigCPtr);
      return ret;
    } 
  }

  public double max_gain {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_max_gain_set(swigCPtr, value);
    } 
    get {
      double ret = VivoxCoreInstancePINVOKE.vx_channel_t_max_gain_get(swigCPtr);
      return ret;
    } 
  }

  public int dist_model {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_dist_model_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_dist_model_get(swigCPtr);
      return ret;
    } 
  }

  public int encrypt_audio {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_encrypt_audio_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_encrypt_audio_get(swigCPtr);
      return ret;
    } 
  }

  public string owner_display_name {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_owner_display_name_set(swigCPtr, value);
    } 
    get {
      string ret = VivoxCoreInstancePINVOKE.vx_channel_t_owner_display_name_get(swigCPtr);
      return ret;
    } 
  }

  public int active_participants {
    set {
      VivoxCoreInstancePINVOKE.vx_channel_t_active_participants_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vx_channel_t_active_participants_get(swigCPtr);
      return ret;
    } 
  }

  public vx_channel_t() : this(VivoxCoreInstancePINVOKE.new_vx_channel_t(), true) {
  }

}

}
