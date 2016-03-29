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
public class ZKId : IRecord, IComparable 
{
#if !NET_CORE
private static ILog log = LogManager.GetLogger(typeof(ZKId));
#endif
  public ZKId() {
  }
  public ZKId(
  string scheme
,
  string id
) {
Scheme=scheme;
Id=id;
  }
  public string Scheme { get; set; } 
  public string Id { get; set; } 
  public void Serialize(IOutputArchive a_, String tag) {
    a_.StartRecord(this,tag);
    a_.WriteString(Scheme,"scheme");
    a_.WriteString(Id,"id");
    a_.EndRecord(this,tag);
  }
  public void Deserialize(IInputArchive a_, String tag) {
    a_.StartRecord(tag);
    Scheme=a_.ReadString("scheme");
    Id=a_.ReadString("id");
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
    a_.WriteString(Scheme,"scheme");
    a_.WriteString(Id,"id");
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
    ZKId peer = (ZKId) obj;
    if (peer == null) {
      throw new InvalidOperationException("Comparing different types of records.");
    }
    int ret = 0;
    ret = Scheme.CompareTo(peer.Scheme);
    if (ret != 0) return ret;
    ret = Id.CompareTo(peer.Id);
    if (ret != 0) return ret;
     return ret;
  }
  public override bool Equals(object obj) {
 ZKId peer = (ZKId) obj;
    if (peer == null) {
      return false;
    }
    if (Object.ReferenceEquals(peer,this)) {
      return true;
    }
    bool ret = false;
    ret = Scheme.Equals(peer.Scheme);
    if (!ret) return ret;
    ret = Id.Equals(peer.Id);
    if (!ret) return ret;
     return ret;
  }
  public override int GetHashCode() {
    int result = 17;
    int ret = GetType().GetHashCode();
    result = 37*result + ret;
    ret = Scheme.GetHashCode();
    result = 37*result + ret;
    ret = Id.GetHashCode();
    result = 37*result + ret;
    return result;
  }
  public static string Signature() {
    return "LId(ss)";
  }
}
}
