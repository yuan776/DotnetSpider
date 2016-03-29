// File generated by hadoop record compiler. Do not edit.
/**
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
#if !NET_CORE
using log4net;
#endif
using ZooKeeperNet.Jute;

namespace ZooKeeperNet.Generate
{
public class TxnHeader : IRecord, IComparable 
{
    #if !NET_CORE
private static ILog log = LogManager.GetLogger(typeof(TxnHeader));
#endif
  public TxnHeader() {
  }
  public TxnHeader(
  long clientId
,
  int cxid
,
  long zxid
,
  long time
,
  int type
) {
ClientId=clientId;
Cxid=cxid;
Zxid=zxid;
Time=time;
Type=type;
  }
  public long ClientId { get; set; } 
  public int Cxid { get; set; } 
  public long Zxid { get; set; } 
  public long Time { get; set; } 
  public int Type { get; set; } 
  public void Serialize(IOutputArchive a_, String tag) {
    a_.StartRecord(this,tag);
    a_.WriteLong(ClientId,"clientId");
    a_.WriteInt(Cxid,"cxid");
    a_.WriteLong(Zxid,"zxid");
    a_.WriteLong(Time,"time");
    a_.WriteInt(Type,"type");
    a_.EndRecord(this,tag);
  }
  public void Deserialize(IInputArchive a_, String tag) {
    a_.StartRecord(tag);
    ClientId=a_.ReadLong("clientId");
    Cxid=a_.ReadInt("cxid");
    Zxid=a_.ReadLong("zxid");
    Time=a_.ReadLong("time");
    Type=a_.ReadInt("type");
    a_.EndRecord(tag);
}
  public override String ToString() {
    try {
      System.IO.MemoryStream ms = new System.IO.MemoryStream();
      using(ZooKeeperNet.IO.EndianBinaryWriter writer =
        new ZooKeeperNet.IO.EndianBinaryWriter(ZooKeeperNet.IO.EndianBitConverter.Big, ms, System.Text.Encoding.UTF8)){
      BinaryOutputArchive a_ = 
        new BinaryOutputArchive(writer);
      a_.StartRecord(this,string.Empty);
    a_.WriteLong(ClientId,"clientId");
    a_.WriteInt(Cxid,"cxid");
    a_.WriteLong(Zxid,"zxid");
    a_.WriteLong(Time,"time");
    a_.WriteInt(Type,"type");
      a_.EndRecord(this,string.Empty);
      ms.Position = 0;
      return System.Text.Encoding.UTF8.GetString(ms.ToArray());
    }    } catch (Exception ex) {
        #if !NET_CORE
      log.Error(ex);
      #endif
    }
    return "ERROR";
  }
  public void Write(ZooKeeperNet.IO.EndianBinaryWriter writer) {
    BinaryOutputArchive archive = new BinaryOutputArchive(writer);
    Serialize(archive, string.Empty);
  }
  public void ReadFields(ZooKeeperNet.IO.EndianBinaryReader reader) {
    BinaryInputArchive archive = new BinaryInputArchive(reader);
    Deserialize(archive, string.Empty);
  }
  public int CompareTo (object obj) {
    TxnHeader peer = (TxnHeader) obj;
    if (peer == null) {
      throw new InvalidOperationException("Comparing different types of records.");
    }
    int ret = 0;
    ret = (ClientId == peer.ClientId)? 0 :((ClientId<peer.ClientId)?-1:1);
    if (ret != 0) return ret;
    ret = (Cxid == peer.Cxid)? 0 :((Cxid<peer.Cxid)?-1:1);
    if (ret != 0) return ret;
    ret = (Zxid == peer.Zxid)? 0 :((Zxid<peer.Zxid)?-1:1);
    if (ret != 0) return ret;
    ret = (Time == peer.Time)? 0 :((Time<peer.Time)?-1:1);
    if (ret != 0) return ret;
    ret = (Type == peer.Type)? 0 :((Type<peer.Type)?-1:1);
    if (ret != 0) return ret;
     return ret;
  }
  public override bool Equals(object obj) {
 TxnHeader peer = (TxnHeader) obj;
    if (peer == null) {
      return false;
    }
    if (Object.ReferenceEquals(peer,this)) {
      return true;
    }
    bool ret = false;
    ret = (ClientId==peer.ClientId);
    if (!ret) return ret;
    ret = (Cxid==peer.Cxid);
    if (!ret) return ret;
    ret = (Zxid==peer.Zxid);
    if (!ret) return ret;
    ret = (Time==peer.Time);
    if (!ret) return ret;
    ret = (Type==peer.Type);
    if (!ret) return ret;
     return ret;
  }
  public override int GetHashCode() {
    int result = 17;
    int ret = GetType().GetHashCode();
    result = 37*result + ret;
    ret = (int)ClientId;
    result = 37*result + ret;
    ret = (int)Cxid;
    result = 37*result + ret;
    ret = (int)Zxid;
    result = 37*result + ret;
    ret = (int)Time;
    result = 37*result + ret;
    ret = (int)Type;
    result = 37*result + ret;
    return result;
  }
  public static string Signature() {
    return "LTxnHeader(lilli)";
  }
}
}
