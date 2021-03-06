// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: pkg.HandShake.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GoPlay.Package {

  /// <summary>Holder for reflection information generated from pkg.HandShake.proto</summary>
  public static partial class PkgHandShakeReflection {

    #region Descriptor
    /// <summary>File descriptor for pkg.HandShake.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PkgHandShakeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNwa2cuSGFuZFNoYWtlLnByb3RvEgNwa2ciJgoISG9zdFBvcnQSDAoESG9z",
            "dBgBIAEoCRIMCgRQb3J0GAIgASgFIlEKE0hhbmRTaGFrZUNsaWVudERhdGES",
            "EgoKQ2xpZW50VHlwZRgBIAEoCRIVCg1DbGllbnRWZXJzaW9uGAIgASgJEg8K",
            "B0RpY3RNZDUYAyABKAki6gEKEUhhbmRTaGFrZVJlc3BvbnNlEhUKDVNlcnZl",
            "clZlcnNpb24YASABKAkSCwoDTm93GAIgASgJEhUKDUhlYXJ0QmVhdFJhdGUY",
            "AyABKAUSMgoGUm91dGVzGAQgAygLMiIucGtnLkhhbmRTaGFrZVJlc3BvbnNl",
            "LlJvdXRlc0VudHJ5EhMKC0lzUmVjb25uZWN0GAUgASgIEiIKC1JlY29ubmVj",
            "dFRvGAYgASgLMg0ucGtnLkhvc3RQb3J0Gi0KC1JvdXRlc0VudHJ5EgsKA2tl",
            "eRgBIAEoCRINCgV2YWx1ZRgCIAEoDToCOAFCEaoCDkdvUGxheS5QYWNrYWdl",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GoPlay.Package.HostPort), global::GoPlay.Package.HostPort.Parser, new[]{ "Host", "Port" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GoPlay.Package.HandShakeClientData), global::GoPlay.Package.HandShakeClientData.Parser, new[]{ "ClientType", "ClientVersion", "DictMd5" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GoPlay.Package.HandShakeResponse), global::GoPlay.Package.HandShakeResponse.Parser, new[]{ "ServerVersion", "Now", "HeartBeatRate", "Routes", "IsReconnect", "ReconnectTo" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class HostPort : pb::IMessage<HostPort> {
    private static readonly pb::MessageParser<HostPort> _parser = new pb::MessageParser<HostPort>(() => new HostPort());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HostPort> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GoPlay.Package.PkgHandShakeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HostPort() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HostPort(HostPort other) : this() {
      host_ = other.host_;
      port_ = other.port_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HostPort Clone() {
      return new HostPort(this);
    }

    /// <summary>Field number for the "Host" field.</summary>
    public const int HostFieldNumber = 1;
    private string host_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Host {
      get { return host_; }
      set {
        host_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Port" field.</summary>
    public const int PortFieldNumber = 2;
    private int port_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HostPort);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HostPort other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Host != other.Host) return false;
      if (Port != other.Port) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Host.Length != 0) hash ^= Host.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Host.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Host);
      }
      if (Port != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Port);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Host.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Host);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Port);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HostPort other) {
      if (other == null) {
        return;
      }
      if (other.Host.Length != 0) {
        Host = other.Host;
      }
      if (other.Port != 0) {
        Port = other.Port;
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
            Host = input.ReadString();
            break;
          }
          case 16: {
            Port = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class HandShakeClientData : pb::IMessage<HandShakeClientData> {
    private static readonly pb::MessageParser<HandShakeClientData> _parser = new pb::MessageParser<HandShakeClientData>(() => new HandShakeClientData());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HandShakeClientData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GoPlay.Package.PkgHandShakeReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeClientData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeClientData(HandShakeClientData other) : this() {
      clientType_ = other.clientType_;
      clientVersion_ = other.clientVersion_;
      dictMd5_ = other.dictMd5_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeClientData Clone() {
      return new HandShakeClientData(this);
    }

    /// <summary>Field number for the "ClientType" field.</summary>
    public const int ClientTypeFieldNumber = 1;
    private string clientType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ClientType {
      get { return clientType_; }
      set {
        clientType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ClientVersion" field.</summary>
    public const int ClientVersionFieldNumber = 2;
    private string clientVersion_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ClientVersion {
      get { return clientVersion_; }
      set {
        clientVersion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "DictMd5" field.</summary>
    public const int DictMd5FieldNumber = 3;
    private string dictMd5_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DictMd5 {
      get { return dictMd5_; }
      set {
        dictMd5_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HandShakeClientData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HandShakeClientData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ClientType != other.ClientType) return false;
      if (ClientVersion != other.ClientVersion) return false;
      if (DictMd5 != other.DictMd5) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ClientType.Length != 0) hash ^= ClientType.GetHashCode();
      if (ClientVersion.Length != 0) hash ^= ClientVersion.GetHashCode();
      if (DictMd5.Length != 0) hash ^= DictMd5.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ClientType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ClientType);
      }
      if (ClientVersion.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ClientVersion);
      }
      if (DictMd5.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(DictMd5);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ClientType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ClientType);
      }
      if (ClientVersion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ClientVersion);
      }
      if (DictMd5.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DictMd5);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HandShakeClientData other) {
      if (other == null) {
        return;
      }
      if (other.ClientType.Length != 0) {
        ClientType = other.ClientType;
      }
      if (other.ClientVersion.Length != 0) {
        ClientVersion = other.ClientVersion;
      }
      if (other.DictMd5.Length != 0) {
        DictMd5 = other.DictMd5;
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
            ClientType = input.ReadString();
            break;
          }
          case 18: {
            ClientVersion = input.ReadString();
            break;
          }
          case 26: {
            DictMd5 = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class HandShakeResponse : pb::IMessage<HandShakeResponse> {
    private static readonly pb::MessageParser<HandShakeResponse> _parser = new pb::MessageParser<HandShakeResponse>(() => new HandShakeResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HandShakeResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GoPlay.Package.PkgHandShakeReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeResponse(HandShakeResponse other) : this() {
      serverVersion_ = other.serverVersion_;
      now_ = other.now_;
      heartBeatRate_ = other.heartBeatRate_;
      routes_ = other.routes_.Clone();
      isReconnect_ = other.isReconnect_;
      ReconnectTo = other.reconnectTo_ != null ? other.ReconnectTo.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HandShakeResponse Clone() {
      return new HandShakeResponse(this);
    }

    /// <summary>Field number for the "ServerVersion" field.</summary>
    public const int ServerVersionFieldNumber = 1;
    private string serverVersion_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ServerVersion {
      get { return serverVersion_; }
      set {
        serverVersion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Now" field.</summary>
    public const int NowFieldNumber = 2;
    private string now_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Now {
      get { return now_; }
      set {
        now_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "HeartBeatRate" field.</summary>
    public const int HeartBeatRateFieldNumber = 3;
    private int heartBeatRate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int HeartBeatRate {
      get { return heartBeatRate_; }
      set {
        heartBeatRate_ = value;
      }
    }

    /// <summary>Field number for the "Routes" field.</summary>
    public const int RoutesFieldNumber = 4;
    private static readonly pbc::MapField<string, uint>.Codec _map_routes_codec
        = new pbc::MapField<string, uint>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForUInt32(16), 34);
    private readonly pbc::MapField<string, uint> routes_ = new pbc::MapField<string, uint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, uint> Routes {
      get { return routes_; }
    }

    /// <summary>Field number for the "IsReconnect" field.</summary>
    public const int IsReconnectFieldNumber = 5;
    private bool isReconnect_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsReconnect {
      get { return isReconnect_; }
      set {
        isReconnect_ = value;
      }
    }

    /// <summary>Field number for the "ReconnectTo" field.</summary>
    public const int ReconnectToFieldNumber = 6;
    private global::GoPlay.Package.HostPort reconnectTo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GoPlay.Package.HostPort ReconnectTo {
      get { return reconnectTo_; }
      set {
        reconnectTo_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HandShakeResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HandShakeResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ServerVersion != other.ServerVersion) return false;
      if (Now != other.Now) return false;
      if (HeartBeatRate != other.HeartBeatRate) return false;
      if (!Routes.Equals(other.Routes)) return false;
      if (IsReconnect != other.IsReconnect) return false;
      if (!object.Equals(ReconnectTo, other.ReconnectTo)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ServerVersion.Length != 0) hash ^= ServerVersion.GetHashCode();
      if (Now.Length != 0) hash ^= Now.GetHashCode();
      if (HeartBeatRate != 0) hash ^= HeartBeatRate.GetHashCode();
      hash ^= Routes.GetHashCode();
      if (IsReconnect != false) hash ^= IsReconnect.GetHashCode();
      if (reconnectTo_ != null) hash ^= ReconnectTo.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ServerVersion.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ServerVersion);
      }
      if (Now.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Now);
      }
      if (HeartBeatRate != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(HeartBeatRate);
      }
      routes_.WriteTo(output, _map_routes_codec);
      if (IsReconnect != false) {
        output.WriteRawTag(40);
        output.WriteBool(IsReconnect);
      }
      if (reconnectTo_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(ReconnectTo);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ServerVersion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ServerVersion);
      }
      if (Now.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Now);
      }
      if (HeartBeatRate != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(HeartBeatRate);
      }
      size += routes_.CalculateSize(_map_routes_codec);
      if (IsReconnect != false) {
        size += 1 + 1;
      }
      if (reconnectTo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReconnectTo);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HandShakeResponse other) {
      if (other == null) {
        return;
      }
      if (other.ServerVersion.Length != 0) {
        ServerVersion = other.ServerVersion;
      }
      if (other.Now.Length != 0) {
        Now = other.Now;
      }
      if (other.HeartBeatRate != 0) {
        HeartBeatRate = other.HeartBeatRate;
      }
      routes_.Add(other.routes_);
      if (other.IsReconnect != false) {
        IsReconnect = other.IsReconnect;
      }
      if (other.reconnectTo_ != null) {
        if (reconnectTo_ == null) {
          reconnectTo_ = new global::GoPlay.Package.HostPort();
        }
        ReconnectTo.MergeFrom(other.ReconnectTo);
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
            ServerVersion = input.ReadString();
            break;
          }
          case 18: {
            Now = input.ReadString();
            break;
          }
          case 24: {
            HeartBeatRate = input.ReadInt32();
            break;
          }
          case 34: {
            routes_.AddEntriesFrom(input, _map_routes_codec);
            break;
          }
          case 40: {
            IsReconnect = input.ReadBool();
            break;
          }
          case 50: {
            if (reconnectTo_ == null) {
              reconnectTo_ = new global::GoPlay.Package.HostPort();
            }
            input.ReadMessage(reconnectTo_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
