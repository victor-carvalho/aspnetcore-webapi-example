﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApi.ContactService.Data;

namespace WebApi.ContactService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180119013824_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebApi.ContactService.Models.Endereco", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Numero");

                    b.Property<Guid>("PessoaID");

                    b.HasKey("ID");

                    b.HasIndex("PessoaID");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("WebApi.ContactService.Models.Pessoa", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Age");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WebApi.ContactService.Models.Endereco", b =>
                {
                    b.HasOne("WebApi.ContactService.Models.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
