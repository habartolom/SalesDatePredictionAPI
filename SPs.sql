USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetNextPredictedOrder]    Script Date: 9/04/2023 7:21:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Get next predicted order per customer
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetNextPredictedOrder]
	@customerName NVARCHAR(100),
	@sortColumn INT,
	@orderingDirection NVARCHAR(4),
	@pageNumber INT,
	@pageSize INT,
	@total INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Offset INT = (@pageNumber - 1) * @pageSize;

	SELECT @total = COUNT(distinct c.custid) 
	FROM Sales.Customers as c join Sales.Orders as o on c.custid = o.custid
	WHERE c.companyname LIKE '%' + @customerName + '%'
	;
	
	SELECT * 
	FROM (
		SELECT 
			result.CustomerId,
			result.CompanyName as CustomerName, 
			result.LastOrderDate, 
			DATEADD(DAY, (result.DayDifference / result.TotalNumberOfOrders), result.LastOrderDate) AS NextPredictedOrder 
		FROM
		(
			SELECT 
				c.custid AS CustomerId, 
				c.companyname AS CompanyName, 
				MIN(o.orderdate) AS FirstOrderDate, 
				MAX(o.orderdate) AS LastOrderDate, 
				DATEDIFF(DAY, MIN(o.orderdate),MAX(o.orderdate)) AS DayDifference, 
				COUNT(*) AS TotalNumberOfOrders
			FROM Sales.Customers AS c
			join Sales.Orders AS o ON c.custid = o.custid
			GROUP BY c.custid, c.companyname
		) AS result
	) AS paged
	WHERE paged.CustomerName LIKE '%' + @customerName + '%'
	ORDER BY 
        CASE WHEN @sortColumn = 0 AND @orderingDirection = 'ASC' THEN paged.CustomerId END ASC,
        CASE WHEN @sortColumn = 0 AND @orderingDirection = 'DESC' THEN paged.CustomerId END DESC,
        CASE WHEN @sortColumn = 1 AND @orderingDirection = 'ASC' THEN paged.CustomerName END ASC,
        CASE WHEN @sortColumn = 1 AND @orderingDirection = 'DESC' THEN paged.CustomerName END DESC,
        CASE WHEN @sortColumn = 2 AND @orderingDirection = 'ASC' THEN paged.LastOrderDate END ASC,
        CASE WHEN @sortColumn = 2 AND @orderingDirection = 'DESC' THEN paged.LastOrderDate END DESC,
        CASE WHEN @sortColumn = 3 AND @orderingDirection = 'ASC' THEN paged.NextPredictedOrder END ASC,
        CASE WHEN @sortColumn = 3 AND @orderingDirection = 'DESC' THEN paged.NextPredictedOrder END DESC

    OFFSET @Offset ROWS
    FETCH NEXT @pageSize ROWS ONLY;
	
END
GO



USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetOrdersByCustomer]    Script Date: 9/04/2023 7:22:13 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Gets the customer orders
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetOrdersByCustomer]
	-- Add the parameters for the stored procedure here
	@CustomerId int,
	@sortColumn INT,
	@orderingDirection NVARCHAR(4),
	@pageNumber INT,
	@pageSize INT,
	@total INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Offset INT = (@pageNumber - 1) * @pageSize;

	SELECT @total = COUNT(*)
	FROM Sales.Orders AS o
	INNER JOIN Sales.Customers AS c ON o.custid = c.custid
	WHERE c.custid = @CustomerId;

	SELECT
		o.Orderid,
		o.Requireddate,
		o.Shippeddate,
		o.Shipname,
		o.Shipaddress,
		o.Shipcity
	FROM Sales.Orders AS o
	INNER JOIN Sales.Customers AS c ON o.custid = c.custid
	WHERE c.custid = @CustomerId
	ORDER BY 
        CASE WHEN @sortColumn = 0 AND @orderingDirection = 'ASC' THEN o.Orderid END ASC,
        CASE WHEN @sortColumn = 0 AND @orderingDirection = 'DESC' THEN o.Orderid END DESC,
        CASE WHEN @sortColumn = 1 AND @orderingDirection = 'ASC' THEN o.Requireddate END ASC,
        CASE WHEN @sortColumn = 1 AND @orderingDirection = 'DESC' THEN o.Requireddate END DESC,
        CASE WHEN @sortColumn = 2 AND @orderingDirection = 'ASC' THEN o.Shippeddate END ASC,
        CASE WHEN @sortColumn = 2 AND @orderingDirection = 'DESC' THEN o.Shippeddate END DESC,
        CASE WHEN @sortColumn = 3 AND @orderingDirection = 'ASC' THEN o.Shipname END ASC,
        CASE WHEN @sortColumn = 3 AND @orderingDirection = 'DESC' THEN o.Shipname END DESC,
		CASE WHEN @sortColumn = 4 AND @orderingDirection = 'ASC' THEN o.Shipaddress END ASC,
        CASE WHEN @sortColumn = 4 AND @orderingDirection = 'DESC' THEN o.Shipaddress END DESC,
		CASE WHEN @sortColumn = 4 AND @orderingDirection = 'ASC' THEN o.Shipcity END ASC,
        CASE WHEN @sortColumn = 4 AND @orderingDirection = 'DESC' THEN o.Shipcity END DESC

    OFFSET @Offset ROWS
    FETCH NEXT @pageSize ROWS ONLY;
END
GO


USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllEmployees]    Script Date: 9/04/2023 7:22:51 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Get all employees
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		e.empid as Empid, 
		CONCAT(Firstname, ' ', Lastname) AS FullName
	FROM HR.Employees AS e
	ORDER BY FullName
END
GO


USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllShippers]    Script Date: 9/04/2023 7:23:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Get all Shippers
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllShippers]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Shipperid,
		Companyname
	FROM
		Sales.Shippers
	ORDER BY Companyname;
END
GO


USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllProducts]    Script Date: 9/04/2023 7:23:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Get all products
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllProducts]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		p.productid,
		p.productname
	FROM
		Production.Products as p
	ORDER BY p.productname;
END
GO


USE [StoreSample]
GO

/****** Object:  StoredProcedure [dbo].[sp_CreateOrderWithProduct]    Script Date: 9/04/2023 7:24:05 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harold Bartolo
-- Create date: 2023-04-10
-- Description:	Add an order with product
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateOrderWithProduct]
	-- Add the parameters for the stored procedure here
	@customerId INT,
	@employeeId INT,
	@orderDate DATETIME,
	@requiredDate DATETIME,
	@shipperId INT,
	@freight MONEY,
	@shipName NVARCHAR(40),
	@shipAddress NVARCHAR(60),
	@shipCity NVARCHAR(15),
	@shipCountry NVARCHAR(15),
	@productId INT,
	@unitPrice MONEY,
	@quantity SMALLINT,
	@discount NUMERIC(4,3),
	@orderId INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @shippedDate DATETIME = NULL;
	DECLARE @shipPostalCode NVARCHAR(10) = NULL;

  INSERT INTO Sales.Orders 
    ( custid, empid, orderdate, requireddate, shippeddate, shipperid, freight, shipname, shipaddress, shipcity, shipregion, shippostalcode, shipcountry)
  VALUES 
    ( @CustomerId, @EmployeeId,	@OrderDate, @RequiredDate, @ShippedDate, @ShipperId, @Freight,	@ShipName,	@ShipAddress,	@ShipCity,	null, null, @ShipCountry  );

  SET @orderId = SCOPE_IDENTITY();

  INSERT INTO Sales.OrderDetails 
    ( orderid, productid, unitprice, qty, discount )
  VALUES 
    ( @orderId, @ProductId, @Unitprice, @Quantity, @Discount );

END
GO


