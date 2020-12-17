using ApiCatalogo.Context;
using ApiCatalogo.Controllers;
using ApiCatalogo.DTOs;
using ApiCatalogo.DTOs.Mappings;
using ApiCatalogo.Repository;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiCatalogoxUnitTests {
    public class CategoriasUnitTestsController {

        private IMapper mapper;
        private IUnityOfWork repository;

        public static DbContextOptions<AppDbContext> dbContextOptions { get;}

        public static string connectionString = "Server=localhost;DataBase=CatalogoDB;Uid=root;Pwd=root";

        static CategoriasUnitTestsController() {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseMySql(connectionString).Options;
        }

        public CategoriasUnitTestsController() {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);

            repository = new UnityOfWork(context);
        
        }


        // testar metodo GET
        [Fact]
        public void GetCategorias_Return_OkResult() {
                var controller = new CategoriasController(repository, mapper);

                var data = controller.Get();
                Assert.IsType<List<CategoriaDTO>>(data.Value);

        }

        [Fact]
        public void GetCategorias_Return_BadRequestResult() {
            var controller = new CategoriasController(repository, mapper);

            var data = controller.Get();
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public void GetCategorias_MatchResult() {
            var controller = new CategoriasController(repository, mapper);

            var data = controller.Get();
            Assert.IsType<List<CategoriaDTO>>(data.Value);

            var cat = data.Value.Should().BeAssignableTo<List<CategoriaDTO>>().Subject;

            Assert.Equal("Bebidas", cat[0].Nome);
            Assert.Equal("http://www.macoratti.net/Imagens/1.jpg", cat[0].ImageUrl);

            Assert.Equal("Sobremesas", cat[2].Nome);
            Assert.Equal("http://www.macoratti.net/Imagens/3.jpg", cat[2].ImageUrl);
        }

        [Fact]
        public async void Task<GetCategoriaById_Return_OkResult>() {
            var controller = new CategoriasController(repository, mapper);
            var catId = 2;

            var data = await controller.Get(catId);
            Console.WriteLine(data);

            Assert.IsType<CategoriaDTO>(data.Value);
        }
    }
}
