//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace C4d {

public class LocalFileTime : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal LocalFileTime(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LocalFileTime obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~LocalFileTime() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_LocalFileTime(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public ushort year {
    set {
      C4dApiPINVOKE.LocalFileTime_year_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_year_get(swigCPtr);
      return ret;
    } 
  }

  public ushort month {
    set {
      C4dApiPINVOKE.LocalFileTime_month_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_month_get(swigCPtr);
      return ret;
    } 
  }

  public ushort day {
    set {
      C4dApiPINVOKE.LocalFileTime_day_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_day_get(swigCPtr);
      return ret;
    } 
  }

  public ushort hour {
    set {
      C4dApiPINVOKE.LocalFileTime_hour_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_hour_get(swigCPtr);
      return ret;
    } 
  }

  public ushort minute {
    set {
      C4dApiPINVOKE.LocalFileTime_minute_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_minute_get(swigCPtr);
      return ret;
    } 
  }

  public ushort second {
    set {
      C4dApiPINVOKE.LocalFileTime_second_set(swigCPtr, value);
    } 
    get {
      ushort ret = C4dApiPINVOKE.LocalFileTime_second_get(swigCPtr);
      return ret;
    } 
  }

  public void Init() {
    C4dApiPINVOKE.LocalFileTime_Init(swigCPtr);
  }

  public int Compare(LocalFileTime t0, LocalFileTime t1) {
    int ret = C4dApiPINVOKE.LocalFileTime_Compare(swigCPtr, LocalFileTime.getCPtr(t0), LocalFileTime.getCPtr(t1));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public LocalFileTime() : this(C4dApiPINVOKE.new_LocalFileTime(), true) {
  }

}

}