using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PluginLib
{
    [Serializable]
    public class BaseClone<T>
    {
        public virtual T Clone()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (T)formatter.Deserialize(memoryStream);
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 级别 1：管理员，2：安装者，3：使用者
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 所拥有的权限
        /// </summary>
        public PermissionsData PermissionData { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0} Password:{1} Level:{2}", Name, Password, Level);
        }
    }

    /// <summary>
    /// 权限
    /// </summary>
    [Serializable]
    public class PermissionsData : BaseClone<PermissionsData>
    {
        /// <summary>
        /// 用户级别:1:Productor,1:Installer,2:User
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 菜单是否可用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 上一级是否可用
        /// </summary>
        public bool ParentEnable { get; set; }

        /// <summary>
        /// 插件权限
        /// </summary>
        public IList<MenuPermissions> MenuPermissions { get; set; }
    }

    /// <summary>
    /// 菜单项权限
    /// </summary>
    [Serializable]
    public class MenuPermissions:BaseClone<MenuPermissions>
    {
        public MenuPermissions()
        {
            PluginPermissions = new List<PluginPermissions>();
        }
        /// <summary>
        /// 菜单唯一标示
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 菜单是否可用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 上一级是否可用
        /// </summary>
        public bool ParentEnable { get; set; }

        /// <summary>
        /// 插件权限
        /// </summary>
        public IList<PluginPermissions> PluginPermissions { get; set; }
    }

    /// <summary>
    /// 插件权限
    /// </summary>
    [Serializable]
    public class PluginPermissions:BaseClone<PluginPermissions>
    {
        public PluginPermissions()
        {
            DataItemsPermissions = new List<PluginPermissionsDataItem>();
        }

        /// <summary>
        /// 插件唯一标识
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 插件名称
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 是否拥有此插件的使用权限
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 上一级是否可用
        /// </summary>
        public bool ParentEnable { get; set; }

        /// <summary>
        /// 对插件子功能项的操作的权限
        /// </summary>
        public IList<PluginPermissionsDataItem> DataItemsPermissions { get; set; }

    }

    /// <summary>
    /// 插件权限个体
    /// </summary>
    [Serializable]
    public class PluginPermissionsDataItem:BaseClone<PluginPermissionsDataItem>
    {
        public PluginPermissionsDataItem()
        {
            SubItemsPermissions = new List<PluginPermissionsDataItem>();
        }

        public string ID { get; set; }

        public bool Enable { get; set; }

        /// <summary>
        /// 上一级是否可用
        /// </summary>
        public bool ParentEnable { get; set; }

        public Point Location { get; set; }

        public string Text { get; set; }

        public string SourceText { get; set; }

        public IList<PluginPermissionsDataItem> SubItemsPermissions { get; set; }

    }
}
