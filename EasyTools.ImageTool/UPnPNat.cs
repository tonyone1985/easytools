using System;
using System.Collections.Generic;
using System.Text;
using NATUPNPLib;
using System.Collections;
using System.Net;
using System.IO;

namespace EasyTools.Tools
{

    public enum ProtocolType
    {
        TCP,
        UDP
    }
    /// <summary>
   
    /// <summary>
    /// 端口映射信息
    /// </summary>
    public class PortMappingInfo
    {
        
        public string InternalIP;
        public int ExternalPort;
        public int InternalPort;
        public ProtocolType type;
        public string Description;
        public PortMappingInfo(string internalIP, int externalPort, int internalPort, ProtocolType type, string description)
        {
            this.InternalIP = internalIP;
            this.ExternalPort = externalPort;
            this.InternalPort = internalPort;
            this.type = type;
            this.Description = description;
        }
    }

    public sealed class UPnPNat
    {

        /// 获取本机的上网IP
        /// </summary>
        /// <returns></returns>
        private string GetConnectNetAddress()
        {
            return null;
        }
        private UPnPNATClass _uPnPNAT;


        public IPAddress WanAddr
        {
            get;
            set;
        }

        public UPnPNat()
        {
            try
            {
                WanAddr = IPAddress.Any;



                UPnPNATClass nat = new UPnPNATClass();
                //if (nat.NATEventManager != null && nat.StaticPortMappingCollection != null)
                _uPnPNAT = nat;

                WanAddr = IPAddress.Parse(GetConnectNetAddress());
                


            }
            catch (Exception ex){

                
            }

            if (_uPnPNAT == null)
                throw new NotSupportedException("没有可配置的UPNP NAT活动");
        }
        /// <summary>
        /// 增加端口映射
        /// </summary>
        /// <param name="ExternalPort">外部端口（路由器 NAT设备打开的端口）</param>
        /// <param name="InternalPort">内部端口 本机的端口</param>
        /// <param name="type">协议类型 UDP或TCP</param>
        /// <param name="InternalClient">内网IP地址或主机名</param>
        /// <param name="enable">是否启用</param>
        /// <param name="description">描述信息</param>
        public void AddStaticPortMapping(int ExternalPort, int InternalPort, ProtocolType type, string InternalClient, bool enable, string description)
        {
            _uPnPNAT.StaticPortMappingCollection.Add(ExternalPort, type.ToString().ToUpper(), InternalPort, InternalClient, enable, description);
        }
        /// <summary>
        /// 移除端口映射
        /// </summary>
        /// <param name="ExternalPort">外部端口号</param>
        /// <param name="type">协议类型</param>
        public void RemoveStaticPortMapping(int ExternalPort, ProtocolType type)
        {
            
            _uPnPNAT.StaticPortMappingCollection.Remove(ExternalPort, type.ToString().ToUpper());
        }
        public UPnPNATClass UPnPNAT
        {
            get { return _uPnPNAT; }
        }

        /// <summary>
        /// 获取端口映射信息
        /// </summary>
        public PortMappingInfo[] PortMappingsInfos
        {
            get
            {
                System.Collections.ArrayList portMappings = new ArrayList();
                int count = _uPnPNAT.StaticPortMappingCollection.Count;
                IEnumerator enumerator = _uPnPNAT.StaticPortMappingCollection.GetEnumerator();
                enumerator.Reset();
                for (int i = 0; i < count; i++)
                {
                    IStaticPortMapping mapping = null;
                    try
                    {
                        if (enumerator.MoveNext())
                            mapping = (IStaticPortMapping)enumerator.Current;
                    }
                    catch { }
                    if (mapping != null)
                        portMappings.Add(new PortMappingInfo(mapping.InternalClient, mapping.ExternalPort, mapping.InternalPort, mapping.Protocol == "TCP" ? ProtocolType.TCP : ProtocolType.UDP, mapping.Description));
                }
                PortMappingInfo[] portMappingInfos = new PortMappingInfo[portMappings.Count];
                portMappings.CopyTo(portMappingInfos);
                return portMappingInfos;
            }
        }

    }
}
