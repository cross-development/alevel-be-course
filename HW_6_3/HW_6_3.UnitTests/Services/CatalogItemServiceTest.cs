﻿using Moq;

namespace HW_6_3.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly Mock<IApplicationDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<ILogger<CatalogItemService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly ICatalogItemService _catalogItemService;

    private readonly CatalogItem _testItem = new CatalogItem
    {
        Name = "Name",
        Description = "Description",
        Price = 100,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        PictureFileName = "1.png"
    };

    public CatalogItemServiceTest()
    {
        _dbContextWrapper = new Mock<IApplicationDbContextWrapper<ApplicationDbContext>>();
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _logger = new Mock<ILogger<CatalogItemService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper
            .Setup(context => context.BeginTransactionAsync(CancellationToken.None))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetCatalogItemsAsync_Success()
    {
        // arrange
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 12;
        var testBrandId = 1;
        var testTypeId = 1;

        var paginatedItemsSuccess = new PaginatedData<CatalogItem>
        {
            Data = new List<CatalogItem>
            {
                new CatalogItem
                {
                    Name = "TestName",
                    CatalogBrandId = 1,
                    CatalogTypeId = 1
                }
            },
            TotalCount = testTotalCount,
        };

        var paginatedFilterRequest = new PaginatedFilterRequest
        {
            PageSize = testPageSize,
            PageIndex = testPageIndex,
            BrandId = testBrandId,
            TypeId = testTypeId
        };

        var catalogItem = new CatalogItem
        {
            Name = "TestName",
            CatalogBrandId = 1,
            CatalogTypeId = 1
        };

        var catalogItemDto = new CatalogItemDto
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(repository => repository.GetByPageAsync(
            It.Is<int>(pageIndex => pageIndex == testPageIndex),
            It.Is<int>(pageSize => pageSize == testPageSize),
            It.Is<int?>(brandId => brandId == testBrandId),
            It.Is<int?>(typeId => typeId == testTypeId))
        ).ReturnsAsync(paginatedItemsSuccess);

        _mapper.Setup(mapper => mapper.Map<CatalogItemDto>(
            It.Is<CatalogItem>(item => item.Equals(catalogItem)))
        ).Returns(catalogItemDto);

        // act
        var result = await _catalogItemService.GetCatalogItemsAsync(paginatedFilterRequest);

        // assert
        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogItemsAsync_Failed()
    {
        // arrange
        var testPageIndex = 10000;
        var testPageSize = 10000;
        var testBrandId = 10000;
        var testTypeId = 10000;

        var paginatedFilterRequest = new PaginatedFilterRequest
        {
            PageSize = testPageSize,
            PageIndex = testPageIndex,
            BrandId = testBrandId,
            TypeId = testTypeId
        };

        _catalogItemRepository.Setup(repository => repository.GetByPageAsync(
            It.Is<int>(pageIndex => pageIndex == testPageIndex),
            It.Is<int>(pageSize => pageSize == testPageSize),
            It.Is<int?>(brandId => brandId == testBrandId),
            It.Is<int?>(typeId => typeId == testTypeId))
        ).Returns((Func<PaginatedResponse<CatalogItemDto>>)null!);

        // act
        var result = await _catalogItemService.GetCatalogItemsAsync(paginatedFilterRequest);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCatalogItemByIdAsync_Success()
    {
        // arrange
        var testItemId = 1;
        var testItemName = "TestName";

        var catalogItem = new CatalogItem
        {
            Id = testItemId,
            Name = testItemName,
            CatalogBrandId = 1,
            CatalogTypeId = 1
        };

        var catalogItemDto = new CatalogItemDto
        {
            Id = testItemId,
            Name = testItemName,
        };

        _catalogItemRepository.Setup(repository => repository.GetByIdAsync(
            It.Is<int>(itemId => itemId == testItemId))
        ).ReturnsAsync(catalogItem);

        _mapper.Setup(mapper => mapper.Map<CatalogItemDto>(
            It.Is<CatalogItem>(item => item.Equals(catalogItem)))
        ).Returns(catalogItemDto);

        // act
        var result = await _catalogItemService.GetCatalogItemByIdAsync(testItemId);

        // assert
        result.Should().NotBeNull();
        result?.Id.Should().Be(testItemId);
        result?.Name.Should().Be(testItemName);
    }

    [Fact]
    public async Task GetCatalogItemByIdAsync_Failed()
    {
        // arrange
        var testItemId = 1;

        _catalogItemRepository.Setup(repository => repository.GetByIdAsync(
            It.Is<int>(itemId => itemId == testItemId))
        ).ReturnsAsync((Func<CatalogItem>)null!);

        // act
        var result = await _catalogItemService.GetCatalogItemByIdAsync(testItemId);

        // result
        result.Should().BeNull();
    }

    [Fact]
    public async Task FindCatalogItemAsync_Success()
    {
        // arrange
        var testItemId = 1;
        var testItemName = "TestName";

        var catalogItem = new CatalogItem
        {
            Id = testItemId,
            Name = testItemName
        };

        _catalogItemRepository.Setup(repository => repository.FindOneAsync(
            It.Is<int>(itemId => itemId == testItemId))
        ).ReturnsAsync(catalogItem);

        // act
        var result = await _catalogItemService.FindCatalogItemAsync(testItemId);

        // assert
        result.Should().NotBeNull();
        result?.Id.Should().Be(testItemId);
        result?.Name.Should().Be(testItemName);
    }

    [Fact]
    public async Task FindCatalogItemAsync_Failed()
    {
        // arrange
        var testItemId = 1;

        _catalogItemRepository.Setup(repository => repository.FindOneAsync(
            It.Is<int>(itemId => itemId == testItemId))
        ).ReturnsAsync((Func<CatalogItem>)null!);

        // act
        var result = await _catalogItemService.FindCatalogItemAsync(testItemId);

        // result
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddCatalogItemAsync_Success()
    {
        // arrange
        var testResult = 1;

        var addItemRequest = new AddItemRequest
        {
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            PictureFileName = _testItem.PictureFileName,
            AvailableStock = _testItem.AvailableStock,
            CatalogBrandId = _testItem.CatalogBrandId,
            CatalogTypeId = _testItem.CatalogTypeId
        };

        _catalogItemRepository.Setup(repository => repository.AddAsync(
            It.Is<CatalogItem>(item => item.Equals(_testItem)))
        ).ReturnsAsync(testResult);

        _mapper.Setup(mapper => mapper.Map<CatalogItem>(
            It.Is<AddItemRequest>(item => item.Equals(addItemRequest)))
        ).Returns(_testItem);

        // act
        var result = await _catalogItemService.AddCatalogItemAsync(addItemRequest);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task AddCatalogItemAsync_Failed()
    {
        // arrange
        int? testResult = null;

        var addItemRequest = new AddItemRequest
        {
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            PictureFileName = _testItem.PictureFileName,
            AvailableStock = _testItem.AvailableStock,
            CatalogBrandId = _testItem.CatalogBrandId,
            CatalogTypeId = _testItem.CatalogTypeId
        };

        _catalogItemRepository.Setup(repository => repository.AddAsync(
           It.Is<CatalogItem>(item => item.Equals(addItemRequest)))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.AddCatalogItemAsync(addItemRequest);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateCatalogItemAsync_Success()
    {
        // arrange
        var testItemId = 1;

        var catalogItem = new CatalogItem
        {
            Id = testItemId,
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            PictureFileName = _testItem.PictureFileName,
            AvailableStock = _testItem.AvailableStock,
            CatalogBrandId = _testItem.CatalogBrandId,
            CatalogTypeId = _testItem.CatalogTypeId
        };

        var updateItemRequest = new UpdateItemRequest
        {
            Name = "Name UPD",
            Description = "Description UPD",
            Price = 2,
            PictureFileName = "2.png",
            AvailableStock = 2,
            CatalogBrandId = 2,
            CatalogTypeId = 2
        };

        catalogItem.Name = updateItemRequest.Name ?? catalogItem.Name;
        catalogItem.Description = updateItemRequest.Description ?? catalogItem.Description;
        catalogItem.Price = updateItemRequest.Price ?? catalogItem.Price;
        catalogItem.PictureFileName = updateItemRequest.PictureFileName ?? catalogItem.PictureFileName;
        catalogItem.AvailableStock = updateItemRequest.AvailableStock ?? catalogItem.AvailableStock;
        catalogItem.CatalogBrandId = updateItemRequest.CatalogBrandId ?? catalogItem.CatalogBrandId;
        catalogItem.CatalogTypeId = updateItemRequest.CatalogTypeId ?? catalogItem.CatalogTypeId;

        _catalogItemRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogItem>(brand => brand == catalogItem))
        ).ReturnsAsync(testItemId);

        // act
        var result = await _catalogItemService.UpdateCatalogItemAsync(updateItemRequest, catalogItem);

        // assert
        result.Should().NotBeNull();
        result?.Should().Be(testItemId);
    }

    [Fact]
    public async Task UpdateCatalogItemAsync_WithDefaultValues_Success()
    {
        // arrange
        var testItemId = 1;

        var catalogItem = new CatalogItem
        {
            Id = testItemId,
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            PictureFileName = _testItem.PictureFileName,
            AvailableStock = _testItem.AvailableStock,
            CatalogBrandId = _testItem.CatalogBrandId,
            CatalogTypeId = _testItem.CatalogTypeId
        };

        var updateItemRequest = new UpdateItemRequest();

        catalogItem.Name = updateItemRequest.Name ?? catalogItem.Name;
        catalogItem.Description = updateItemRequest.Description ?? catalogItem.Description;
        catalogItem.Price = updateItemRequest.Price ?? catalogItem.Price;
        catalogItem.PictureFileName = updateItemRequest.PictureFileName ?? catalogItem.PictureFileName;
        catalogItem.AvailableStock = updateItemRequest.AvailableStock ?? catalogItem.AvailableStock;
        catalogItem.CatalogBrandId = updateItemRequest.CatalogBrandId ?? catalogItem.CatalogBrandId;
        catalogItem.CatalogTypeId = updateItemRequest.CatalogTypeId ?? catalogItem.CatalogTypeId;

        _catalogItemRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogItem>(brand => brand == catalogItem))
        ).ReturnsAsync(testItemId);

        // act
        var result = await _catalogItemService.UpdateCatalogItemAsync(updateItemRequest, catalogItem);

        // assert
        result.Should().NotBeNull();
        result?.Should().Be(testItemId);
    }

    [Fact]
    public async Task UpdateCatalogItemAsync_Failed()
    {
        // arrange
        int? testResult = null;

        var catalogItem = new CatalogItem
        {
            Id = 1,
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            PictureFileName = _testItem.PictureFileName,
            AvailableStock = _testItem.AvailableStock,
            CatalogBrandId = _testItem.CatalogBrandId,
            CatalogTypeId = _testItem.CatalogTypeId
        };

        var updateItemRequest = new UpdateItemRequest
        {
            Name = "Name UPD",
            Description = "Description UPD",
            Price = 2,
            PictureFileName = "2.png",
            AvailableStock = 2,
            CatalogBrandId = 2,
            CatalogTypeId = 2
        };

        catalogItem.Name = updateItemRequest.Name ?? catalogItem.Name;
        catalogItem.Description = updateItemRequest.Description ?? catalogItem.Description;
        catalogItem.Price = updateItemRequest.Price ?? catalogItem.Price;
        catalogItem.PictureFileName = updateItemRequest.PictureFileName ?? catalogItem.PictureFileName;
        catalogItem.AvailableStock = updateItemRequest.AvailableStock ?? catalogItem.AvailableStock;
        catalogItem.CatalogBrandId = updateItemRequest.CatalogBrandId ?? catalogItem.CatalogBrandId;
        catalogItem.CatalogTypeId = updateItemRequest.CatalogTypeId ?? catalogItem.CatalogTypeId;

        _catalogItemRepository.Setup(repository => repository.UpdateAsync(
            It.Is<CatalogItem>(item => item == catalogItem))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.UpdateCatalogItemAsync(updateItemRequest, catalogItem);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteCatalogItemAsync_Success()
    {
        // arrange
        var testResult = true;

        var catalogItem = new CatalogItem
        {
            Id = 1,
            Name = "TestName"
        };

        _catalogItemRepository.Setup(repository => repository.DeleteAsync(
            It.Is<CatalogItem>(item => item == catalogItem))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.DeleteCatalogItemAsync(catalogItem);

        // assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteCatalogItemAsync_Failed()
    {
        // arrange
        var testResult = false;

        var catalogItem = new CatalogItem
        {
            Id = 1,
            Name = "TestName"
        };

        _catalogItemRepository.Setup(repository => repository.DeleteAsync(
            It.Is<CatalogItem>(item => item == catalogItem))
        ).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.DeleteCatalogItemAsync(catalogItem);

        // result
        result.Should().BeFalse();
    }
}