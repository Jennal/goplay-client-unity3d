// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: pkg.ErrorMessage.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GoPlay.Package {

  /// <summary>Holder for reflection information generated from pkg.ErrorMessage.proto</summary>
  public static partial class PkgErrorMessageReflection {

    #region Descriptor
    /// <summary>File descriptor for pkg.ErrorMessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PkgErrorMessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZwa2cuRXJyb3JNZXNzYWdlLnByb3RvEgNwa2ciOgoMRXJyb3JNZXNzYWdl",
            "EhkKBENvZGUYASABKA4yCy5wa2cuU3RhdHVzEg8KB01lc3NhZ2UYAiABKAkq",
            "cgoGU3RhdHVzEgYKAk9LEAASCAoDRVJSEJABEhUKEEVSUl9XUk9OR19QQVJB",
            "TVMQkQESFgoRRVJSX0RFQ09ERV9GQUlMRUQQkgESEAoLRVJSX1RJTUVPVVQQ",
            "kwESFQoQRVJSX0VNUFRZX1JFU1VMVBCUAUIRqgIOR29QbGF5LlBhY2thZ2Vi",
            "BnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::GoPlay.Package.Status), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GoPlay.Package.ErrorMessage), global::GoPlay.Package.ErrorMessage.Parser, new[]{ "Code", "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum Status {
    [pbr::OriginalName("OK")] Ok = 0,
    [pbr::OriginalName("ERR")] Err = 144,
    [pbr::OriginalName("ERR_WRONG_PARAMS")] ErrWrongParams = 145,
    [pbr::OriginalName("ERR_DECODE_FAILED")] ErrDecodeFailed = 146,
    [pbr::OriginalName("ERR_TIMEOUT")] ErrTimeout = 147,
    [pbr::OriginalName("ERR_EMPTY_RESULT")] ErrEmptyResult = 148,
  }

  #endregion

  #region Messages
  public sealed partial class ErrorMessage : pb::IMessage<ErrorMessage> {
    private static readonly pb::MessageParser<ErrorMessage> _parser = new pb::MessageParser<ErrorMessage>(() => new ErrorMessage());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ErrorMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GoPlay.Package.PkgErrorMessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorMessage(ErrorMessage other) : this() {
      code_ = other.code_;
      message_ = other.message_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorMessage Clone() {
      return new ErrorMessage(this);
    }

    /// <summary>Field number for the "Code" field.</summary>
    public const int CodeFieldNumber = 1;
    private global::GoPlay.Package.Status code_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GoPlay.Package.Status Code {
      get { return code_; }
      set {
        code_ = value;
      }
    }

    /// <summary>Field number for the "Message" field.</summary>
    public const int MessageFieldNumber = 2;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ErrorMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ErrorMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Code != other.Code) return false;
      if (Message != other.Message) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Code != 0) hash ^= Code.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Code != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Code);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Message);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Code != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Code);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ErrorMessage other) {
      if (other == null) {
        return;
      }
      if (other.Code != 0) {
        Code = other.Code;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            code_ = (global::GoPlay.Package.Status) input.ReadEnum();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
