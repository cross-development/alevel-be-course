namespace HW_6_3.UnitTests.Services;

public class CatalogBrandServiceTest
{
    private readonly Mock<IApplicationDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
    private readonly Mock<ILogger<CatalogBrandService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandServiceTest()
    {
        _dbContextWrapper = new Mock<IApplicationDbContextWrapper<ApplicationDbContext>>();
        _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
        _logger = new Mock<ILogger<CatalogBrandService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper
            .Setup(context => context.BeginTransactionAsync(CancellationToken.None))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetCatalogBrandsAsync_Success()
    {
        // arrange
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 12;

        var paginatedBrandsSuccess = new PaginatedData<CatalogBrand>
        {
            Data = new List<CatalogBrand>
            {
                new CatalogBrand
                {
                    Brand = "TestName"
                }
            },
            TotalCount = testTotalCount
        };

        var paginatedRequest = new PaginatedRequest
        {
            PageIndex = testPageIndex,
            PageSize = testPageSize
        };

        var catalogBrand = new CatalogBrand
        {
            Brand = "TestName"
        };

        var catalogBrandDto = new CatalogBrandDto
        {
            Brand = "TestName"
        };

        _catalogBrandRepository.Setup(repository => repository.GetByPageAsync(
                It.Is<int>(pageIndex => pageIndex == testPageIndex),
                It.Is<int>(pageSize => pageSize == testPageSize))
        ).ReturnsAsync(paginatedBrandsSuccess);

        _mapper.Setup(mapper => mapper.Map<CatalogBrandDto>(
                It.Is<CatalogBrand>(brand => brand.Equals(catalogBrand)))
        ).Returns(catalogBrandDto);

        // act
        var result = await _catalogBrandService.GetCatalogBrandsAsync(paginatedRequest);

        // assert
        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogBrandsAsync_Failed()
    {
        // arrange
        var testPageIndex = 10000;
        var testPageSize = 10000;

        var paginatedRequest = new PaginatedRequest
        {
            PageIndex = testPageIndex,
            PageSize = testPageSize
        };

        _catalogBrandRepository.Setup(repository => repository.GetByPageAsync(
            It.Is<int>(pageIndex => pageIndex == testPageIndex),
            It.Is<int>(pageSize => pageSize == testPageSize))
        ).Returns((Func<PaginatedResponse<CatalogBrandDto>>)null!);

        // act
        var result = await _catalogBrandService.GetCatalogBrandsAsync(paginatedRequest);

        // result
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCatalogBrandByIdAsync_Success()
    {
        // arrange
        var testBrandId = 1;
        var testBrandName = "TestName";

        var catalogBrand = new CatalogBrand
        {
            Id = testBrandId,
            Brand = testBrandName
        };

        var catalogBrandDto = new CatalogBrandDto
        {
            Id = testBrandId,
            Brand = testBrandName
        };

        _catalogBrandRepository.Setup(repository => repository.GetByIdAsync(
            It.Is<int>(brandId => brandId == testBrandId))
        ).ReturnsAsync(catalogBrand);

        _mapper.Setup(mapper => mapper.Map<CatalogBrandDto>(
            It.Is<CatalogBrand>(brand => brand.Equals(catalogBrand)))
        ).Returns(catalogBrandDto);

        // act
        var result = await _catalogBrandService.GetCatalogBrandByIdAsync(testBrandId);

        // assert
        result.Should().NotBeNull();
        result?.Brand.Should().Be(testBrandName);
        result?.Id.Should().Be(testBrandId);
    }

    [Fact]
    public async Task GetCatalogBrandByIdAsync_Failed()
    {
        // arrange
        var testBrandId = 1;

        _catalogBrandRepository.Setup(repository => repository.GetByIdAsync(
            It.Is<int>(brandId => brandId == testBrandId))
        ).ReturnsAsync((Func<CatalogBrand>)null!);

        // act
        var result = await _catalogBrandService.GetCatalogBrandByIdAsync(testBrandId);

        // result
        result.Should().BeNull();
    }

    [Fact]
    public async Task FindCatalogBrandAsync_Success()
    {
        // arrange
        var testBrandId = 1;
        var testBrandName = "TestName";

        var catalogBrand = new CatalogBrand
        {
            Id = testBrandId,
            Brand = testBrandName
        };

        _catalogBrandRepository.Setup(repository => repository.FindOneAsync(
            It.Is<int>(brandId => brandId == testBrandId))
        ).ReturnsAsync(catalogBrand);

        // act
        var result = await _catalogBrandService.FindCatalogBrandAsync(testBrandId);

        // assert
        result.Should().NotBeNull();
        result?.Id.Should().Be(testBrandId);
        result?.Brand.Should().Be(testBrandName);
    }

    [Fact]
    public async Task FindCatalogBrandAsync_Failed()
    {
        // arrange
        var testBrandId = 1;

        _catalogBrandRepository.Setup(repository => repository.FindOneAsync(
            It.Is<int>(brandId => brandId == testBrandId))
        ).ReturnsAsync((Func<CatalogBrand>)null!);

        // act
        var result = await _catalogBrandService.FindCatalogBrandAsync(testBrandId);

        // result
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddCatalogBrandAsync_Success()
    {
        // arrange
        var testBrandId = 1;

        var catalogBrand = new CatalogBrand
        {
            Id = testBrandId,
            Brand = "TestName"
        };

        var addBrandRequest = new AddBrandRequest
        {
            Brand = catalogBrand.Brand
        };

        _catalogBrandRepository.Setup(repository => repository.AddAsync(
                It.Is<CatalogBrand>(brand => brand.Equals(catalogBrand)))
        ).ReturnsAsync(testBrandId);

        _mapper.Setup(mapper => mapper.Map<CatalogBrand>(
            It.Is<AddBrandRequest>(brand => brand.Equals(addBrandRequest)))
        ).Returns(catalogBrand);

        // act
        var result = await _catalogBrandService.AddCatalogBrandAsync(addBrandRequest);

        // assert
        result.Should().Be(testBrandId);
    }

    [Fact]
    public async Task AddCatalogBrandAsync_Failed()
    {
        // arrange
        int? testResult = null;

        var addBrandRequest = new AddBrandRequest
        {
            Brand = "TestName"
        };

        _catalogBrandRepository.Setup(repository => repository.AddAsync(
                It.Is<CatalogBrand>(brand => brand.Equals(addBrandRequest)))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.AddCatalogBrandAsync(addBrandRequest);

        // assert
        result.Should().Be(testResult);
    }


    [Fact]
    public async Task UpdateCatalogBrandAsync_Success()
    {
        // arrange
        var testBrandId = 1;

        var catalogBrand = new CatalogBrand
        {
            Id = testBrandId,
            Brand = "TestName"
        };

        var updateBrandRequest = new UpdateBrandRequest
        {
            Brand = "TestName UPD"
        };

        catalogBrand.Brand = updateBrandRequest.Brand ?? catalogBrand.Brand;

        _catalogBrandRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogBrand>(brand => brand == catalogBrand))
        ).ReturnsAsync(testBrandId);

        // act
        var result = await _catalogBrandService.UpdateCatalogBrandAsync(updateBrandRequest, catalogBrand);

        // assert
        result.Should().NotBeNull();
        result?.Should().Be(testBrandId);
    } 
    
    [Fact]
    public async Task UpdateCatalogBrandAsync_WithDefaultValues_Success()
    {
        // arrange
        var testBrandId = 1;

        var catalogBrand = new CatalogBrand
        {
            Id = testBrandId,
            Brand = "TestName"
        };

        var updateBrandRequest = new UpdateBrandRequest();

        catalogBrand.Brand = updateBrandRequest.Brand ?? catalogBrand.Brand;

        _catalogBrandRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogBrand>(brand => brand == catalogBrand))
        ).ReturnsAsync(testBrandId);

        // act
        var result = await _catalogBrandService.UpdateCatalogBrandAsync(updateBrandRequest, catalogBrand);

        // assert
        result.Should().NotBeNull();
        result?.Should().Be(testBrandId);
    }

    [Fact]
    public async Task UpdateCatalogBrandAsync_Failed()
    {
        // arrange
        int? testResult = null;

        var catalogBrand = new CatalogBrand
        {
            Id = 1,
            Brand = "TestName"
        };

        var updateBrandRequest = new UpdateBrandRequest
        {
            Brand = "TestName UPD"
        };

        catalogBrand.Brand = updateBrandRequest.Brand ?? catalogBrand.Brand;

        _catalogBrandRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogBrand>(brand => brand == catalogBrand))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.UpdateCatalogBrandAsync(updateBrandRequest, catalogBrand);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteCatalogBrandAsync_Success()
    {
        // arrange
        var testResult = true;

        var catalogBrand = new CatalogBrand
        {
            Id = 1,
            Brand = "TestName"
        };

        _catalogBrandRepository.Setup(repository => repository.DeleteAsync(
            It.Is<CatalogBrand>(brand => brand == catalogBrand))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.DeleteCatalogBrandAsync(catalogBrand);

        // assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteCatalogBrandAsync_Failed()
    {
        // arrange
        var testResult = false;

        var catalogBrand = new CatalogBrand
        {
            Id = 1,
            Brand = "TestName"
        };

        _catalogBrandRepository.Setup(repository => repository.DeleteAsync(
            It.Is<CatalogBrand>(brand => brand == catalogBrand))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.DeleteCatalogBrandAsync(catalogBrand);

        // result
        result.Should().BeFalse();
    }
}