﻿using SakuraHardwareRegister.Common;
using Dapper;

namespace SakuraHardwareRegister.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Active_Flag { get; set; }

        // 引数なしのコンストラクタがないとDapperがエラーになる
        public Locations() { }

        // 拠点情報取得
        public static IEnumerable<Locations> MultiSelect(bool? _active_flag = null)
        {
            using (var con = DbConnector.GetDbConnector())
            {
                con.Open();
                if (_active_flag is null)
                {
                    return con.Query<Locations>(
                    "SELECT * From shr.locations");
                }
                else
                {
                    return con.Query<Locations>(
                    "SELECT * From shr.locations WHERE active_flag = @active_flag",
                    new { active_flag = _active_flag });
                }
            }
        }

        // 拠点情報保存
        public void Insert()
        {
            using (var con = DbConnector.GetDbConnector())
            {
                con.Open();
                con.Query<Locations>(
                    "INSERT INTO shr.locations (id, name, active_flag) VALUES (@Id, @Name, @Active_Flag)",
                    this);
            }
        }
    }
}
