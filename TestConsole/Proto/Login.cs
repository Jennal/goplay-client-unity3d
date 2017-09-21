// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: login.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protobuf.Login {

  /// <summary>Holder for reflection information generated from login.proto</summary>
  public static partial class LoginReflection {

    #region Descriptor
    /// <summary>File descriptor for login.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LoginReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgtsb2dpbi5wcm90bxIFbG9naW4iFAoSUmVnaXN0R3Vlc3RSZXF1ZXN0IiYK",
            "EUxvZ2luVG9rZW5SZXF1ZXN0EhEKCVVzZXJUb2tlbhgBIAEoCSIyCgxMb2dp",
            "blJlcXVlc3QSEAoIVXNlcm5hbWUYASABKAkSEAoIUGFzc3dvcmQYAiABKAki",
            "MQoNTG9naW5SZXNwb25zZRIRCglVc2VyVG9rZW4YASABKAkSDQoFUG93ZXIY",
            "AiABKAUiJAoQQ2hlY2tVc2VyUmVxdWVzdBIQCghVc2VybmFtZRgBIAEoCSIj",
            "ChFDaGVja1VzZXJSZXNwb25zZRIOCgZSZXN1bHQYASABKAhCEaoCDlByb3Rv",
            "YnVmLkxvZ2luYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.RegistGuestRequest), global::Protobuf.Login.RegistGuestRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.LoginTokenRequest), global::Protobuf.Login.LoginTokenRequest.Parser, new[]{ "UserToken" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.LoginRequest), global::Protobuf.Login.LoginRequest.Parser, new[]{ "Username", "Password" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.LoginResponse), global::Protobuf.Login.LoginResponse.Parser, new[]{ "UserToken", "Power" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.CheckUserRequest), global::Protobuf.Login.CheckUserRequest.Parser, new[]{ "Username" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.Login.CheckUserResponse), global::Protobuf.Login.CheckUserResponse.Parser, new[]{ "Result" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RegistGuestRequest : pb::IMessage<RegistGuestRequest> {
    private static readonly pb::MessageParser<RegistGuestRequest> _parser = new pb::MessageParser<RegistGuestRequest>(() => new RegistGuestRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RegistGuestRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegistGuestRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegistGuestRequest(RegistGuestRequest other) : this() {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegistGuestRequest Clone() {
      return new RegistGuestRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RegistGuestRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RegistGuestRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RegistGuestRequest other) {
      if (other == null) {
        return;
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
        }
      }
    }

  }

  public sealed partial class LoginTokenRequest : pb::IMessage<LoginTokenRequest> {
    private static readonly pb::MessageParser<LoginTokenRequest> _parser = new pb::MessageParser<LoginTokenRequest>(() => new LoginTokenRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginTokenRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginTokenRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginTokenRequest(LoginTokenRequest other) : this() {
      userToken_ = other.userToken_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginTokenRequest Clone() {
      return new LoginTokenRequest(this);
    }

    /// <summary>Field number for the "UserToken" field.</summary>
    public const int UserTokenFieldNumber = 1;
    private string userToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string UserToken {
      get { return userToken_; }
      set {
        userToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginTokenRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginTokenRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserToken != other.UserToken) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserToken.Length != 0) hash ^= UserToken.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserToken);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserToken);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginTokenRequest other) {
      if (other == null) {
        return;
      }
      if (other.UserToken.Length != 0) {
        UserToken = other.UserToken;
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
          case 10: {
            UserToken = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoginRequest : pb::IMessage<LoginRequest> {
    private static readonly pb::MessageParser<LoginRequest> _parser = new pb::MessageParser<LoginRequest>(() => new LoginRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest(LoginRequest other) : this() {
      username_ = other.username_;
      password_ = other.password_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest Clone() {
      return new LoginRequest(this);
    }

    /// <summary>Field number for the "Username" field.</summary>
    public const int UsernameFieldNumber = 1;
    private string username_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Password" field.</summary>
    public const int PasswordFieldNumber = 2;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Username != other.Username) return false;
      if (Password != other.Password) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Username.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Username);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginRequest other) {
      if (other == null) {
        return;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
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
          case 10: {
            Username = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoginResponse : pb::IMessage<LoginResponse> {
    private static readonly pb::MessageParser<LoginResponse> _parser = new pb::MessageParser<LoginResponse>(() => new LoginResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginResponse(LoginResponse other) : this() {
      userToken_ = other.userToken_;
      power_ = other.power_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginResponse Clone() {
      return new LoginResponse(this);
    }

    /// <summary>Field number for the "UserToken" field.</summary>
    public const int UserTokenFieldNumber = 1;
    private string userToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string UserToken {
      get { return userToken_; }
      set {
        userToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Power" field.</summary>
    public const int PowerFieldNumber = 2;
    private int power_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Power {
      get { return power_; }
      set {
        power_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserToken != other.UserToken) return false;
      if (Power != other.Power) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserToken.Length != 0) hash ^= UserToken.GetHashCode();
      if (Power != 0) hash ^= Power.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserToken);
      }
      if (Power != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Power);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserToken);
      }
      if (Power != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Power);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginResponse other) {
      if (other == null) {
        return;
      }
      if (other.UserToken.Length != 0) {
        UserToken = other.UserToken;
      }
      if (other.Power != 0) {
        Power = other.Power;
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
          case 10: {
            UserToken = input.ReadString();
            break;
          }
          case 16: {
            Power = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CheckUserRequest : pb::IMessage<CheckUserRequest> {
    private static readonly pb::MessageParser<CheckUserRequest> _parser = new pb::MessageParser<CheckUserRequest>(() => new CheckUserRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CheckUserRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserRequest(CheckUserRequest other) : this() {
      username_ = other.username_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserRequest Clone() {
      return new CheckUserRequest(this);
    }

    /// <summary>Field number for the "Username" field.</summary>
    public const int UsernameFieldNumber = 1;
    private string username_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CheckUserRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CheckUserRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Username != other.Username) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Username.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Username);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CheckUserRequest other) {
      if (other == null) {
        return;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
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
          case 10: {
            Username = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CheckUserResponse : pb::IMessage<CheckUserResponse> {
    private static readonly pb::MessageParser<CheckUserResponse> _parser = new pb::MessageParser<CheckUserResponse>(() => new CheckUserResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CheckUserResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.Login.LoginReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserResponse(CheckUserResponse other) : this() {
      result_ = other.result_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CheckUserResponse Clone() {
      return new CheckUserResponse(this);
    }

    /// <summary>Field number for the "Result" field.</summary>
    public const int ResultFieldNumber = 1;
    private bool result_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CheckUserResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CheckUserResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != false) hash ^= Result.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != false) {
        output.WriteRawTag(8);
        output.WriteBool(Result);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != false) {
        size += 1 + 1;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CheckUserResponse other) {
      if (other == null) {
        return;
      }
      if (other.Result != false) {
        Result = other.Result;
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
            Result = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code