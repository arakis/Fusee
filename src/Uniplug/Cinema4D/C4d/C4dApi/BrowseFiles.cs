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

public class BrowseFiles : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BrowseFiles(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BrowseFiles obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static BrowseFiles Alloc() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BrowseFiles_Alloc();
    BrowseFiles ret = (cPtr == global::System.IntPtr.Zero) ? null : new BrowseFiles(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_BrowseFiles bf) {
    C4dApiPINVOKE.BrowseFiles_Free(SWIGTYPE_p_p_BrowseFiles.getCPtr(bf));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Init(Filename directory, int flags) {
    C4dApiPINVOKE.BrowseFiles_Init(swigCPtr, Filename.getCPtr(directory), flags);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool GetNext() {
    bool ret = C4dApiPINVOKE.BrowseFiles_GetNext(swigCPtr);
    return ret;
  }

  public long GetSize() {
    long ret = C4dApiPINVOKE.BrowseFiles_GetSize(swigCPtr);
    return ret;
  }

  public bool IsDir() {
    bool ret = C4dApiPINVOKE.BrowseFiles_IsDir(swigCPtr);
    return ret;
  }

  public bool IsHidden() {
    bool ret = C4dApiPINVOKE.BrowseFiles_IsHidden(swigCPtr);
    return ret;
  }

  public bool IsBundle() {
    bool ret = C4dApiPINVOKE.BrowseFiles_IsBundle(swigCPtr);
    return ret;
  }

  public bool IsReadOnly() {
    bool ret = C4dApiPINVOKE.BrowseFiles_IsReadOnly(swigCPtr);
    return ret;
  }

  public void GetFileTime(int mode, LocalFileTime arg1) {
    C4dApiPINVOKE.BrowseFiles_GetFileTime(swigCPtr, mode, LocalFileTime.getCPtr(arg1));
  }

  public Filename GetFilename() {
    Filename ret = new Filename(C4dApiPINVOKE.BrowseFiles_GetFilename(swigCPtr), true);
    return ret;
  }

}

}