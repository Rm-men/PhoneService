using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable

namespace ServiceDB.Models
{
    public partial class ListSirvice
    {
        public static List<ListSirvice> GetServices()
        {
            return (from s in Context.db.ListSirvices
                    select new ListSirvice()
                    {
                        Id = s.Id,
                        Namesrv = s.Namesrv,
                        Typesrv = s.Typesrv,
                        Descriptionsrv = s.Descriptionsrv,
                        Costsrv = s.Costsrv,
                        Timesrv = s.Timesrv,
                    }).ToList();

        }

        public bool UpadateServiceADO()
        {
            var command = new NpgsqlCommand("UPdate list_sirvices set namesrv = @namesrv, typesrv = @typesrv, descriptionsrv = @descriptionsrv, costsrv = @costsrv where id = @id", Context.npgsql);
            NpgsqlParameter orderParam = new NpgsqlParameter("@id", this.Id);
            NpgsqlParameter statusParam = new NpgsqlParameter("@namesrv", this.Namesrv);
            NpgsqlParameter typeParan = new NpgsqlParameter("@typesrv", this.Typesrv);
            NpgsqlParameter costParam = new NpgsqlParameter("@costsrv", this.Costsrv);
            NpgsqlParameter descrParam = new NpgsqlParameter("@descriptionsrv", this.Descriptionsrv);
            command.Parameters.Add(orderParam);
            command.Parameters.Add(statusParam);
            command.Parameters.Add(typeParan);
            command.Parameters.Add(costParam);
            command.Parameters.Add(descrParam);
            var query = command.ExecuteNonQuery();
            Context.db.Entry(this).Reload();
            return query > 0;
        }
        public bool AddServiceADO()
        {
            var command = new NpgsqlCommand("INSERT INTO list_sirvices (namesrv, typesrv, descriptionsrv, costsrv) VALUES (@namesrv, @typesrv, @descriptionsrv, @costsrv)", Context.npgsql);
            NpgsqlParameter nParam = new NpgsqlParameter("@namesrv", this.Namesrv);
            NpgsqlParameter tParam = new NpgsqlParameter("@typesrv", this.Typesrv);
            NpgsqlParameter dParam = new NpgsqlParameter("@descriptionsrv", this.Descriptionsrv);
            NpgsqlParameter cParam = new NpgsqlParameter("@costsrv", this.Costsrv);
            command.Parameters.Add(nParam);
            command.Parameters.Add(tParam);
            command.Parameters.Add(dParam);
            command.Parameters.Add(cParam);
            var query = command.ExecuteNonQuery();
            Context.db.Entry(this).Reload();
            return query > 0;
        }

        public static List<ListSirvice> GetServicesADO()
        {
            var command = new NpgsqlCommand("select * from list_sirvices", Context.npgsql);

            List<ListSirvice> listserv = new List<ListSirvice>();

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListSirvice srv= new ListSirvice();
                        srv.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        srv.Namesrv = reader.GetString(reader.GetOrdinal("namesrv"));
                        srv.Typesrv = reader.GetString(reader.GetOrdinal("typesrv"));
                        srv.Descriptionsrv = reader.GetString(reader.GetOrdinal("descriptionsrv"));
                        srv.Costsrv = reader.GetDecimal(reader.GetOrdinal("costsrv"));
                        listserv.Add(srv);
                    }
                }
            }
            return listserv;
        }
    }
}
