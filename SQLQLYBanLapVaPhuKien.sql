
-- Tạo cơ sở dữ liệu
CREATE DATABASE LaptopStore3;
GO

USE LaptopStore3;
GO


/***** Bảng Khách hàng (Customer) *****/
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1), 
    FullName NVARCHAR(255) NOT NULL,          
    Phone NVARCHAR(10) NULL,   
    Address NVARCHAR(255),    
    CONSTRAINT CK_Phone_Length_Cus CHECK (Phone IS NULL OR LEN(Phone) = 10)
);

/***** Bảng Nhân viên (Employee) *****/
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),  
    FullName NVARCHAR(255) NOT NULL,           
    Phone NVARCHAR(10)NULL,  
    Address NVARCHAR(255),
    Position NVARCHAR(100) NOT NULL,    
    Salary DECIMAL(18,2) NOT NULL CHECK (Salary >= 0),
    HireDate DATETIME DEFAULT GETDATE(),  
    Status VARCHAR(20) NOT NULL CHECK (Status IN ('Đang làm việc', 'Đã Nghỉ Việc')), 
    CONSTRAINT CK_Phone_Length_Emp CHECK (Phone IS NULL OR LEN(Phone) = 10)
);

/***** Bảng Nhà cung cấp (Supplier) *****/
CREATE TABLE Supplier (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SpName NVARCHAR(255) NOT NULL,
    Contact NVARCHAR(255) NOT NULL CHECK (LEN(Contact) = 10 OR Contact LIKE '%@%'),
    Address NVARCHAR(255) NOT NULL
);

/***** Bảng Sản phẩm (Product) *****/
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Brand NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL CHECK (Price >= 0),
    WarrantyPeriod INT CHECK (WarrantyPeriod >= 0),
    Description NVARCHAR(MAX),
    Image VARBINARY(MAX) NULL,
    FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID) ON DELETE SET NULL
);

/***** Bảng Tồn kho (Stock) *****/
CREATE TABLE Stock (
    ProductID INT PRIMARY KEY,
    Quantity INT CHECK (Quantity >= 0),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE
);

/***** Bảng Đơn hàng (Order) *****/
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    EmployeeID INT NOT NULL,
    OrderDate DATETIME NOT NULL CHECK (OrderDate <= GETDATE()),
    TotalAmount DECIMAL(18,2) CHECK (TotalAmount >= 0),
    Status NVARCHAR(20) CHECK (Status IN (N'Chờ xử lý',N'Đang giao',N'Đã giao',N'Đã hủy')),
    PaymentMethod NVARCHAR(50) CHECK (PaymentMethod IN (N'Tiền mặt', N'Thẻ tín dụng', N'Chuyển khoản ngân hàng')),
    ShippingAddress NVARCHAR(255),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE
);

/***** Bảng Chi tiết đơn hàng (OrderDetails) *****/
CREATE TABLE OrderDetails (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT CHECK (Quantity > 0),
    Price DECIMAL(18,2) CHECK (Price >= 0),
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE
);

/***** Bảng Bảo hành (Warranty) *****/
CREATE TABLE Warranty (
    WarrantyID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    CustomerID INT NOT NULL,
    StartDate DATETIME DEFAULT GETDATE(),
    EndDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN (N'Còn hiệu lực',N'Hết hạn',N'Đang xử lý')),
    WarrantyCenter NVARCHAR(255) NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE
);

/***** Bảng Tài khoản (Account) *****/
CREATE TABLE Account (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    Username CHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    UserType NVARCHAR(255) NOT NULL CHECK (UserType IN ('Employee', 'Admin', 'Customer')),
    Email NVARCHAR(255) NULL,
    Salt NVARCHAR(255) NULL,
    VerificationCode NVARCHAR(255) NULL,
    VerificationCodeExpiration DATETIME NULL,
    EmployeeID INT NULL,
    CustomerID INT NULL,
    Status BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE SET NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE SET NULL
);

/***** Bảng Nhập hàng (Import) *****/
CREATE TABLE Import (
    ImportID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    ImportDate DATETIME DEFAULT GETDATE(),
    TotalCost DECIMAL(18,2) CHECK (TotalCost >= 0),
    Status NVARCHAR(20) CHECK (Status IN (N'Chờ xử lý',N'Hoàn thành',N'Đã hủy')),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE
);

/***** Bảng Chi tiết nhập hàng (ImportDetail) *****/
CREATE TABLE ImportDetail (
    ImportID INT NOT NULL,
    ProductID INT NOT NULL,
	SupplierID INT NOT NULL,

    Quantity INT CHECK (Quantity > 0),
    Price DECIMAL(18,2) CHECK (Price >= 0),
    PRIMARY KEY (ImportID, ProductID),
    FOREIGN KEY (ImportID) REFERENCES Import(ImportID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE,
	FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID) ON DELETE CASCADE
);
GO

------------------------------------------------------------------------------------
/***** Thêm dữ liệu mẫu cho Customer *****/
INSERT INTO Customer (FullName, Phone, Address) VALUES
(N'Nguyễn Văn Tiến', '0901223344', N'Hà Nội'),
(N'Phạm Thị Hoa', '0912334455', N'Hải Phòng'),
(N'Trần Văn Khoa', '0923445566', N'Đà Nẵng'),
(N'Lê Thị Minh', '0934556677', N'Huế'),
(N'Võ Văn Tài', '0945667788', N'TP. Hồ Chí Minh'),
(N'Hoàng Thu Trang', '0956778899', N'Cần Thơ'),
(N'Bùi Tiến Dũng', '0967889900', N'Nha Trang'),
(N'Đặng Minh Hoàng', '0978990011', N'Bình Định'),
(N'Ngô Hoàng Nam', '0989001122', N'Đồng Nai'),
(N'Đỗ Tiến Phát', '0990112233', N'Thanh Hóa');
GO

/***** Thêm dữ liệu mẫu cho Employee *****/
INSERT INTO Employee (FullName, Phone, Address, Position, Salary, Status) VALUES
(N'Nguyễn Hoàng Long', '0902222333', N'Hà Nội', N'Nhân viên kinh doanh', 9000000, N'Đang làm việc'),
(N'Trần Minh Đức', '0913333444', N'TP. Hồ Chí Minh', N'Kỹ thuật viên', 10000000, N'Đang làm việc'),
(N'Lê Văn Sơn', '0924444555', N'Hải Phòng', N'Hỗ trợ khách hàng', 7800000, N'Đang làm việc'),
(N'Phạm Thị Bình', '0935555666', N'Đà Nẵng', N'Hỗ trợ IT', 9800000, N'Đã nghỉ việc');
GO

/***** Thêm dữ liệu mẫu cho Supplier *****/
INSERT INTO Supplier (SpName, Contact, Address) VALUES
(N'Cửa hàng Công Nghệ', '0933123456', N'Đà Nẵng'),
(N'Thiết Bị Tương Lai', '0944123456', N'Huế'),
(N'Thế Giới Số', '0955123456', N'Bình Dương'),
(N'PC Master', '0966234567', N'Cần Thơ'),
(N'Trung Tâm Laptop', '0977345678', N'Thanh Hóa');
GO

-- Bổ sung thêm dữ liệu cho bảng Product
INSERT INTO Product (SupplierID, ProductName, Category, Brand, Price, WarrantyPeriod, Description) VALUES
(1, N'Laptop ASUS ROG Zephyrus G14', N'Laptop', N'ASUS', 42000000, 36, N'Laptop gaming ASUS ROG Zephyrus G14, Ryzen 9, RTX 4060'),
(2, N'Bàn phím cơ Akko 3068B', N'Bàn phím', N'Akko', 2000000, 12, N'Bàn phím cơ không dây Akko 3068B, Red Switch'),
(3, N'Chuột Razer DeathAdder V2', N'Chuột', N'Razer', 1800000, 24, N'Chuột gaming Razer DeathAdder V2, cảm biến 20K DPI');
GO

/***** Thêm dữ liệu mẫu cho Stock *****/
INSERT INTO Stock (ProductID, Quantity) VALUES
(1, 12),
(2, 20),
(3, 25);
GO

/***** Thêm dữ liệu mẫu cho Order *****/
INSERT INTO [Order] (CustomerID, EmployeeID, OrderDate, TotalAmount, Status, PaymentMethod, ShippingAddress) 
VALUES
(1, 1, '2025-03-19', 28000000, N'Chờ xử lý', N'Thẻ tín dụng', N'Cần Thơ'),
(1, 1, '2025-03-20', 1500000, N'Đã giao', N'Tiền mặt', N'Nha Trang');
GO

/***** Thêm dữ liệu mẫu cho OrderDetails *****/
INSERT INTO OrderDetails(OrderID, ProductID, Quantity, Price) VALUES
(1, 1, 1, 42000000),
(2, 2, 1, 2000000);
GO

/***** Thêm dữ liệu mẫu cho Import *****/
INSERT INTO Import ( EmployeeID, ImportDate, TotalCost, Status) VALUES
( 2, '2025-03-01', 50000000, N'Hoàn thành'),
( 3, '2025-03-05', 42000000, N'Hoàn thành');
GO

/***** Thêm dữ liệu mẫu cho Warranty *****/
INSERT INTO Warranty (ProductID, CustomerID, StartDate, EndDate, Status, WarrantyCenter) VALUES
(1, 6, '2025-03-19', '2027-03-19', N'Còn hiệu lực', N'Trung tâm bảo hành ASUS Hà Nội'),
(2, 7, '2025-03-20', '2026-03-20', N'Còn hiệu lực', N'Trung tâm bảo hành Akko TP. Hồ Chí Minh');
GO
--------------------------------------------------------------------------------------------------------
--Tạo View
-- 1. Xem số lượng sản phẩm đã bán trong ngày
CREATE VIEW View_SoldProductsToday AS
SELECT od.ProductID, p.ProductName, SUM(COALESCE(od.Quantity, 0)) AS TotalSold
FROM OrderDetails od
JOIN [Order] o ON od.OrderID = o.OrderID
JOIN Product p ON od.ProductID = p.ProductID
WHERE CAST(o.OrderDate AS DATE) = CAST(GETDATE() AS DATE)
GROUP BY od.ProductID, p.ProductName;
GO


-- 3. Xem số hàng còn lại trong kho
CREATE VIEW View_StockQuantity AS
SELECT p.ProductID, p.ProductName, s.Quantity
FROM Product p
JOIN Stock s ON p.ProductID = s.ProductID;
GO
-- 4. Xem các đơn hàng chưa giao (Pending)
CREATE VIEW View_PendingOrders AS
SELECT o.OrderID, c.FullName AS CustomerName, e.FullName AS EmployeeName, o.OrderDate, o.TotalAmount
FROM [Order] o
JOIN Customer c ON o.CustomerID = c.CustomerID
LEFT JOIN Employee e ON o.EmployeeID = e.EmployeeID
WHERE o.Status = N'Chờ xử lý';
GO
---------------------------------------------------------------------------------------------------------
--Tạo Trigger
--1.Trigger đặt trạng thái đơn hàng là Pending khi tạo mới
CREATE TRIGGER trg_SetOrderStatus
ON [Order]
AFTER INSERT
AS
BEGIN
    UPDATE [Order]
    SET Status = N'Chờ xử lý'
    FROM [Order] o
    JOIN inserted i ON o.OrderID = i.OrderID;
END;
GO
--4Trigger ngăn chặn trùng lặp tên sản phẩm
CREATE TRIGGER trg_PreventDuplicateProductName
ON Product
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM Product p
        JOIN inserted i ON p.ProductName = i.ProductName
        WHERE p.ProductID <> i.ProductID
    )
    BEGIN
        THROW 50000, 'Tên sản phẩm đã tồn tại. Vui lòng chọn tên khác.', 1;
    END;
END;
GO

-- 6. Ngăn chặn nhập số lượng sản phẩm âm trong ImportDetail
CREATE TRIGGER trg_UpdateTotalAmount
ON OrderDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE o
    SET o.TotalAmount = (
        SELECT COALESCE(SUM(od.Quantity * od.Price), 0)
        FROM OrderDetails od
        WHERE od.OrderID = o.OrderID
    )
    FROM [Order] o
    WHERE EXISTS (SELECT 1 FROM inserted WHERE inserted.OrderID = o.OrderID)
       OR EXISTS (SELECT 1 FROM deleted WHERE deleted.OrderID = o.OrderID);
END;
GO
-- ======================================================
-----------------/* Thêm các Funtion*/----------------
-- ======================================================

-- Function tìm kiếm nhân viên theo tên
CREATE FUNCTION SearchEmployeeByName(@Name NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Employee
    WHERE FullName LIKE '%' + @Name + '%'
);
GO

-- Function tìm kiếm khách hàng theo tên
CREATE FUNCTION SearchCustomerByName(@Name NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Customer
    WHERE FullName LIKE '%' + @Name + '%'
);
GO
-- Function tìm kiếm sản phẩm Laptop theo tên
CREATE FUNCTION SearchLaptopByName(@Name NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Product
    WHERE ProductName LIKE '%' + @Name + '%'
    AND Category = 'Laptop' -- Giả sử cột Category chứa loại sản phẩm
);
GO
-- Function tìm kiếm sản phẩm phụ kiện theo tên
CREATE FUNCTION SearchNonLaptopByName(@Name NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Product
    WHERE ProductName LIKE '%' + @Name + '%'
    AND Category <> 'Laptop' -- Loại trừ laptop
);
GO
-----------------------------------------------------------------------
--Chèn các Stored Procedure
-- =============================================
-- 01. Stored Procedure cho bảng Product
-- =============================================

-- 01.01. Lấy danh sách tất cả sản phẩm
CREATE PROCEDURE spGetAllProducts
AS
BEGIN
    SELECT *
    FROM Product;
END;
GO

-- 01.02. Lấy danh sách sản phẩm theo loại
CREATE PROCEDURE spGetProductsByCategory
    @Category NVARCHAR(100)
AS
BEGIN
    SELECT SupplierID, ProductID, ProductName, Category, Brand, Price, WarrantyPeriod, Description
    FROM Product
    WHERE Category = @Category;
END;
GO

-- 01.03. Thêm một sản phẩm mới
CREATE PROCEDURE spInsertProduct
    @SupplierID INT,
    @ProductName NVARCHAR(255), 
    @Category NVARCHAR(100),
    @Brand NVARCHAR(100),
    @Price DECIMAL(18,2),
    @WarrantyPeriod INT,
    @Description NVARCHAR(500)
AS
BEGIN
    INSERT INTO Product (SupplierID, ProductName, Category, Brand, Price, WarrantyPeriod, Description)
    VALUES (@SupplierID, @ProductName, @Category, @Brand, @Price, @WarrantyPeriod, @Description);
END;
GO

-- 01.04. Cập nhật thông tin sản phẩm
CREATE PROCEDURE spUpdateProduct
    @ProductID INT,
	@SupplierID INT,
    @ProductName NVARCHAR(255),
    @Category NVARCHAR(100),
    @Brand NVARCHAR(100),
    @Price DECIMAL(18,2),
    @WarrantyPeriod INT,
    @Description NVARCHAR(500)
AS
BEGIN
    UPDATE Product
    SET SupplierID = @SupplierID, ProductName = @ProductName, Category = @Category, Brand = @Brand, 
        Price = @Price, WarrantyPeriod = @WarrantyPeriod, Description = @Description
    WHERE ProductID = @ProductID;
END;
GO

-- 01.05. Xóa sản phẩm
CREATE PROCEDURE spDeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Product WHERE ProductID = @ProductID;
END;
GO

-- =============================================
-- 02. Stored Procedure cho bảng Customer
-- =============================================

-- 02.01. Lấy danh sách khách hàng
CREATE PROCEDURE spGetAllCustomers
AS
BEGIN
    SELECT * 
	FROM Customer;
END;
GO

-- 02.02. Thêm khách hàng mới
CREATE PROCEDURE spInsertCustomer
    @FullName NVARCHAR(255),
    @Phone NVARCHAR(10),
    @Address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Customer (FullName, Phone, Address)
    VALUES (@FullName, @Phone, @Address);
END;
GO

-- 02.03. Cập nhật thông tin khách hàng
CREATE PROCEDURE spUpdateCustomer
    @CustomerID INT,
    @FullName NVARCHAR(255),
    @Phone NVARCHAR(10),
    @Address NVARCHAR(255)
AS
BEGIN
    UPDATE Customer
    SET FullName = @FullName, Phone = @Phone, Address = @Address
    WHERE CustomerID = @CustomerID;
END;
GO

-- 02.04. Xóa khách hàng
CREATE PROCEDURE spDeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customer WHERE CustomerID = @CustomerID;
END;
GO

-- =============================================
-- 03. Stored Procedure cho bảng Employee
-- =============================================

-- 03.01. Lấy danh sách nhân viên
CREATE PROCEDURE spGetAllEmployees
AS
BEGIN
    SELECT * FROM Employee;
END;
GO

-- 03.02. Thêm nhân viên mới
CREATE PROCEDURE spInsertEmployee
    @FullName NVARCHAR(255),
    @Phone NVARCHAR(10),
    @Address NVARCHAR(255),
    @Position NVARCHAR(100),
    @Salary DECIMAL(18,2),
    @HireDate DATE,
    @Status NVARCHAR(10)
AS
BEGIN
    INSERT INTO Employee (FullName, Phone, Address, Position, Salary, HireDate, Status)
    VALUES (@FullName, @Phone, @Address, @Position, @Salary, @HireDate, @Status);
END;
GO

-- 03.03. Cập nhật thông tin nhân viên
CREATE PROCEDURE spUpdateEmployee
    @EmployeeID INT,
    @FullName NVARCHAR(255),
    @Phone NVARCHAR(10),
    @Address NVARCHAR(255),
    @Position NVARCHAR(100),
    @Salary DECIMAL(18,2),
    @HireDate DATE,
    @Status NVARCHAR(10)
AS
BEGIN
    UPDATE Employee
    SET FullName = @FullName, Phone = @Phone, Address = @Address, 
        Position = @Position, Salary = @Salary, HireDate = @HireDate, Status = @Status
    WHERE EmployeeID = @EmployeeID;
END;
GO

-- 03.04. Xóa nhân viên
CREATE PROCEDURE spDeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employee WHERE EmployeeID = @EmployeeID;
END;
GO

-- =============================================
-- 04. Stored Procedure cho bảng Order
-- =============================================

-- 04.01. Lấy danh sách đơn hàng
CREATE PROCEDURE spGetAllOrders
AS
BEGIN
    SELECT *
    FROM [Order];
END;
GO

-- 04.02. Tạo đơn hàng mới
CREATE PROCEDURE spInsertOrder
    @CustomerID INT,
    @EmployeeID INT,
    @OrderDate DATE,
    @TotalAmount DECIMAL(18,2),
    @Status NVARCHAR(10),
    @PaymentMethod NVARCHAR(20),
    @ShippingAddress NVARCHAR(255)
AS
BEGIN
    INSERT INTO [Order] (CustomerID, EmployeeID, OrderDate, TotalAmount, Status, PaymentMethod, ShippingAddress)
    VALUES (@CustomerID, @EmployeeID, @OrderDate, @TotalAmount, @Status, @PaymentMethod, @ShippingAddress);
    SELECT SCOPE_IDENTITY() AS NewOrderID;
END;
GO

-- 04.03. Cập nhật trạng thái đơn hàng
CREATE PROCEDURE spUpdateOrderStatus
    @OrderID INT,
    @Status NVARCHAR(10)
AS
BEGIN
    UPDATE [Order]
    SET Status = @Status
    WHERE OrderID = @OrderID;
END;
GO

-- 04.04. Xóa đơn hàng
CREATE PROCEDURE spDeleteOrder
    @OrderID INT
AS
BEGIN
    DELETE FROM [Order] WHERE OrderID = @OrderID;
END;
GO

-- =============================================
-- 05. Stored Procedure cho OrderDetail
-- =============================================

-- 05.01. Lấy chi tiết đơn hàng
CREATE PROCEDURE [dbo].[spGetOrderInfo]
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        o.OrderID, o.OrderDate, o.TotalAmount, o.Status, o.PaymentMethod, o.ShippingAddress AS Addr,
        c.CustomerID, c.FullName AS CustomerName, c.Phone AS CustomerPhone,
        e.EmployeeID, e.FullName AS EmployeeName,
        od.ProductID, p.ProductName, od.Quantity, od.Price,
        (od.Quantity * od.Price) AS TotalPrice
    FROM [Order] o
    JOIN Customer c ON o.CustomerID = c.CustomerID
    LEFT JOIN Employee e ON o.EmployeeID = e.EmployeeID
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Product p ON od.ProductID = p.ProductID
    WHERE o.OrderID = @OrderID;
END;
GO

-- 05.02. Thêm sản phẩm vào đơn hàng
CREATE PROCEDURE spInsertOrderDetail
    @OrderID INT,
    @ProductID INT,
    @Quantity INT,
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price)
    VALUES (@OrderID, @ProductID, @Quantity, @Price);
END;
GO

-- =============================================
-- 06. Stored Procedure cho bảng Stock
-- =============================================

-- 06.01. Lấy danh sách tồn kho
CREATE PROCEDURE spGetAllStock
AS
BEGIN
    SELECT s.ProductID, p.ProductName, s.Quantity
    FROM Stock s
    JOIN Product p ON s.ProductID = p.ProductID;
END;
GO

-- 06.02. Cập nhật số lượng tồn kho
CREATE PROCEDURE spUpdateStock
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    UPDATE Stock
    SET Quantity = @Quantity
    WHERE ProductID = @ProductID;
END;
GO

-- =============================================
-- 07. Stored Procedure cho bảng Supplier
-- =============================================

-- 07.01. Lấy danh sách nhà cung cấp
CREATE PROCEDURE spGetAllSuppliers
AS
BEGIN
    SELECT * FROM Supplier;
END;
GO

-- 07.02. Thêm nhà cung cấp mới
CREATE PROCEDURE spInsertSupplier
    @Name NVARCHAR(255),
    @Contact NVARCHAR(255),
    @Address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Supplier (SpName, Contact, Address)
    VALUES (@Name, @Contact, @Address);
END;
GO

-- 07.03. Cập nhật thông tin nhà cung cấp
CREATE PROCEDURE spUpdateSupplier
    @SupplierID INT,
    @Name NVARCHAR(255),
    @Contact NVARCHAR(255),
    @Address NVARCHAR(255)
AS
BEGIN
    UPDATE Supplier
    SET SpName = @Name, Contact = @Contact, Address = @Address
    WHERE SupplierID = @SupplierID;
END;
GO

-- =============================================
-- 08. Stored Procedure cho bảng Warranty
-- =============================================

-- 08.01. Lấy danh sách bảo hành
CREATE PROCEDURE spGetAllWarranties
AS
BEGIN
    SELECT * FROM Warranty;
END;
GO

-- 08.02. Thêm bảo hành mới
CREATE PROCEDURE spInsertWarranty
    @ProductID INT,
    @CustomerID INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @Status NVARCHAR(20),
    @WarrantyCenter NVARCHAR(255)
AS
BEGIN
    INSERT INTO Warranty (ProductID, CustomerID, StartDate, EndDate, Status, WarrantyCenter)
    VALUES (@ProductID, @CustomerID, @StartDate, @EndDate, @Status, @WarrantyCenter);
END;
GO

-- 08.03. Cập nhật thông tin bảo hành
CREATE PROCEDURE spUpdateWarranty
    @WarrantyID INT,
    @ProductID INT,
    @CustomerID INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @Status NVARCHAR(20),
    @WarrantyCenter NVARCHAR(255)
AS
BEGIN
    UPDATE Warranty
    SET ProductID = @ProductID, CustomerID = @CustomerID, StartDate = @StartDate,
        EndDate = @EndDate, Status = @Status, WarrantyCenter = @WarrantyCenter
    WHERE WarrantyID = @WarrantyID;
END;
GO

-- 08.04. Xóa bảo hành
CREATE PROCEDURE spDeleteWarranty
    @WarrantyID INT
AS
BEGIN
    DELETE FROM Warranty WHERE WarrantyID = @WarrantyID;
END;
GO

-- 08.05. Gia hạn bảo hành
CREATE PROCEDURE spExtendWarranty
    @WarrantyID INT,
    @NewEndDate DATE
AS
BEGIN
    UPDATE Warranty
    SET EndDate = @NewEndDate
    WHERE WarrantyID = @WarrantyID;
END;
GO

-- =============================================
-- 09. Stored Procedure cho bảng Account
-- =============================================

-- 09.01. Thêm tài khoản mới
CREATE PROCEDURE spAddAccount
    @Username NVARCHAR(255),
    @Password NVARCHAR(255),
    @UserType NVARCHAR(255),
    @Email NVARCHAR(255),
    @Salt NVARCHAR(255),
    @VerificationCode NVARCHAR(255) = NULL,
    @VerificationCodeExpiration DATETIME = NULL,
    @EmployeeID INT = NULL,
    @CustomerID INT = NULL
AS
BEGIN
    INSERT INTO Account (Username, Password, UserType, Email, Salt, VerificationCode, VerificationCodeExpiration, EmployeeID, CustomerID, Status)
    VALUES (@Username, @Password, @UserType, @Email, @Salt, @VerificationCode, @VerificationCodeExpiration, @EmployeeID, @CustomerID, 0);
END;
GO

-- 09.02. Cập nhật tài khoản
CREATE PROCEDURE spUpdateAccount
    @AccountID INT,
    @Username CHAR(255) = NULL,
    @Password NVARCHAR(255) = NULL,
    @UserType NVARCHAR(255) = NULL,
    @Email NVARCHAR(255) = NULL,
    @Salt NVARCHAR(255) = NULL,
    @VerificationCode NVARCHAR(255) = NULL,
    @VerificationCodeExpiration DATETIME = NULL,
    @EmployeeID INT = NULL,
    @CustomerID INT = NULL,
    @Status BIT = NULL
AS
BEGIN
    UPDATE Account
    SET 
        Username = ISNULL(@Username, Username),
        Password = ISNULL(@Password, Password),
        UserType = ISNULL(@UserType, UserType),
        Email = ISNULL(@Email, Email),
        Salt = ISNULL(@Salt, Salt),
        VerificationCode = ISNULL(@VerificationCode, VerificationCode),
        VerificationCodeExpiration = ISNULL(@VerificationCodeExpiration, VerificationCodeExpiration),
        EmployeeID = @EmployeeID,
        CustomerID = @CustomerID,
        Status = ISNULL(@Status, Status)
    WHERE AccountID = @AccountID;
END;
GO

-- 09.03. Lấy danh sách tài khoản (ẩn Password, Salt)
CREATE PROCEDURE spGetAccount
AS
BEGIN
    SELECT 
        AccountID, Username, UserType, Email, VerificationCode,
        VerificationCodeExpiration, EmployeeID, CustomerID, Status
    FROM Account;
END;
GO

-- 09.04. Xóa tài khoản
CREATE PROCEDURE spDeleteAccount
    @AccountID INT
AS
BEGIN
    DELETE FROM Account WHERE AccountID = @AccountID;
END;
GO

-- 09.05. Lưu mã xác nhận vào cơ sở dữ liệu
CREATE PROCEDURE spSaveVerificationCode
    @Username NVARCHAR(255),
    @VerificationCode NVARCHAR(255),
    @Expiration DATETIME
AS
BEGIN
    UPDATE Account
    SET VerificationCode = @VerificationCode,
        VerificationCodeExpiration = @Expiration
    WHERE Username = @Username;
END;
GO
-- 9.06. Tạo tài khoản SQL login, add tài khoản login đó vào csdl LaptopStore2 và gán user đó vào vai trò được tao sẵn
CREATE PROCEDURE CreateUserIfNotExists
    @Username NVARCHAR(255),
    @Password NVARCHAR(255),
    @UserType NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Tạo login nếu chưa có (ở cấp server)
    IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = @Username)
    BEGIN
        DECLARE @SQLLogin NVARCHAR(MAX);
        DECLARE @EscapedPassword NVARCHAR(255);

        -- Escape dấu nháy đơn nếu có trong mật khẩu
        SET @EscapedPassword = REPLACE(@Password, '''', '''''');

        SET @SQLLogin = N'CREATE LOGIN [' + @Username + '] WITH PASSWORD = N''' + @EscapedPassword + ''';';
        EXEC (@SQLLogin);
    END

    -- Tạo user trong database nếu chưa tồn tại
    IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = @Username)
    BEGIN
        DECLARE @SQLUser NVARCHAR(MAX);
        SET @SQLUser = N'CREATE USER [' + @Username + '] FOR LOGIN [' + @Username + '];';
        EXEC (@SQLUser);
    END

    -- Gán user vào role phù hợp
    IF @UserType = 'Admin'
    BEGIN
        IF NOT EXISTS (
            SELECT * FROM sys.database_role_members 
            WHERE role_principal_id = DATABASE_PRINCIPAL_ID('dbAdmin') 
              AND member_principal_id = DATABASE_PRINCIPAL_ID(@Username)
        )
        BEGIN
            EXEC sp_addrolemember 'dbAdmin', @Username;
        END
    END
    ELSE IF @UserType = 'Employee'
    BEGIN
        IF NOT EXISTS (
            SELECT * FROM sys.database_role_members 
            WHERE role_principal_id = DATABASE_PRINCIPAL_ID('dbEmployee') 
              AND member_principal_id = DATABASE_PRINCIPAL_ID(@Username)
        )
        BEGIN
            EXEC sp_addrolemember 'dbEmployee', @Username;
        END
    END
    ELSE IF @UserType = 'Customer'
    BEGIN
        IF NOT EXISTS (
            SELECT * FROM sys.database_role_members 
            WHERE role_principal_id = DATABASE_PRINCIPAL_ID('dbCustomer') 
              AND member_principal_id = DATABASE_PRINCIPAL_ID(@Username)
        )
        BEGIN
            EXEC sp_addrolemember 'dbCustomer', @Username;
        END
    END
END

GO
-- =============================================
-- 10. Các Stored Procedure khác
-- =============================================

-- 10.01. Lấy thông tin người dùng theo Username
CREATE PROCEDURE spGetUserInfoByUsername
    @Username NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserType NVARCHAR(50);
    DECLARE @CustomerID INT;
    DECLARE @EmployeeID INT;

    SELECT 
        @UserType = UserType,
        @CustomerID = CustomerID,
        @EmployeeID = EmployeeID
    FROM Account
    WHERE Username = @Username;

    IF @UserType = 'Customer'
    BEGIN
        SELECT 
            a.Username, a.Email, c.CustomerID,
            c.FullName, c.Phone, c.Address,
            'Customer' AS Role
        FROM Customer c
        JOIN Account a ON c.CustomerID = a.CustomerID
        WHERE c.CustomerID = @CustomerID;
    END
    ELSE
    BEGIN
        SELECT 
            a.Username, a.Email, e.EmployeeID,
            e.FullName, e.Phone, e.Address, e.Position, e.Salary, e.HireDate, e.Status,
            @UserType AS Role
        FROM Employee e
        JOIN Account a ON e.EmployeeID = a.EmployeeID
        WHERE e.EmployeeID = @EmployeeID;
    END
END;
GO

-- 10.02. Lấy đơn hàng của khách theo Username
CREATE PROCEDURE spGetOrdersByCustomerUsername
    @Username NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        o.OrderID, o.OrderDate, o.TotalAmount, o.Status, o.PaymentMethod, o.ShippingAddress,
        c.FullName AS CustomerName,
        e.FullName AS EmployeeName
    FROM [Order] o
    INNER JOIN Customer c ON o.CustomerID = c.CustomerID
    INNER JOIN Employee e ON o.EmployeeID = e.EmployeeID
    INNER JOIN Account a ON c.CustomerID = a.CustomerID
    WHERE a.Username = @Username;
END;
GO

-- 10.03. Lấy thông tin sản phẩm (kèm hình ảnh)
CREATE PROCEDURE spLayTenHinhAnh
    @ProductID INT
AS
BEGIN
    SELECT SupplierID, ProductName, Price, Description, Image
	FROM Product
    WHERE ProductID = @ProductID;
END;
GO
----------------------------------------------
-- Stored Procedure có kèm transaction
CREATE TYPE OrderDetailsType AS TABLE --Dữ liệu người dùng tự định nghĩa
(
    ProductID INT,
    Quantity INT,
    Price DECIMAL(18,2)
);
GO
------------------------------------
CREATE PROCEDURE CreateFullOrder
    @CustomerID INT,
    @EmployeeID INT,
    @OrderDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @PaymentMethod NVARCHAR(50),
    @ShippingAddress NVARCHAR(255),
    @OrderDetails OrderDetailsType READONLY,  -- Table-valued parameter
    @NewOrderID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insert vào bảng Order (Không truyền @Status nữa)
        INSERT INTO [Order] (
            CustomerID, EmployeeID, OrderDate, TotalAmount,
            PaymentMethod, ShippingAddress
        ) VALUES (
            @CustomerID, @EmployeeID, @OrderDate, @TotalAmount,
            @PaymentMethod, @ShippingAddress
        );

        -- 2. Lấy ID đơn hàng mới
        SET @NewOrderID = SCOPE_IDENTITY();

        -- 3. Insert vào OrderDetails từ Table-Valued Parameter
        INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price)
        SELECT @NewOrderID, ProductID, Quantity, Price
        FROM @OrderDetails;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- ======================================================
-----------------/* USER VA PHAN QUYEN*/----------------
-- ======================================================
-- Trong database LaptopStore2
USE LaptopStore2;

-- Tạo các ROLE nếu chưa có
CREATE ROLE dbAdmin;
CREATE ROLE dbEmployee;
CREATE ROLE dbCustomer;

-- Gán quyền cho từng ROLE
-- Quyền cho dbAdmin – full access:
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO dbAdmin;

-- Quyền cho dbEmployee – thao tác với đơn hàng, khách, sản phẩm:
-- Quyền đọc/ghi cho các bảng cần thiết
GRANT SELECT ON Account TO dbEmployee;
GRANT SELECT ON Product TO dbEmployee;
GRANT SELECT, INSERT ON [Order] TO dbEmployee;
GRANT SELECT, INSERT ON OrderDetails TO dbEmployee;
GRANT SELECT ON Customer TO dbEmployee;
GRANT UPDATE ON Stock TO dbEmployee;

-- Cấp quyền thực thi toàn bộ Stored Procedures & Functions cho dbEmployee
GRANT EXECUTE TO dbEmployee;
GO

-- Quyền cho dbCustomer – chỉ được xem các bảng cần thiết mà không lọc theo username:
-- Gán quyền SELECT cho dbCustomer trên các bảng cần thiết
GRANT SELECT ON Account TO dbCustomer;
GRANT SELECT ON Customer TO dbCustomer;
GRANT SELECT ON [Order] TO dbCustomer;
GRANT SELECT ON OrderDetails TO dbCustomer;
GRANT SELECT ON Product TO dbCustomer;

-- Cấp quyền thực thi toàn bộ Stored Procedures & Functions cho dbCustomer
GRANT EXECUTE TO dbCustomer;
GO


GRANT EXECUTE ON OBJECT::dbo.spGetProductsByCategory TO dbCustomer;
GRANT EXECUTE ON OBJECT::dbo.spLayTenHinhAnh TO dbCustomer;
GRANT EXECUTE ON OBJECT::dbo.spGetOrdersByCustomerUsername TO dbCustomer;
GRANT EXECUTE ON OBJECT::dbo.spGetUserInfoByUsername TO dbCustomer;

-- Thêm chi tiết nhập hàng
CREATE PROCEDURE spInsertImportDetail
    @ImportID INT,
    @ProductID INT,
	@SupplierID INT,
    @Quantity INT,
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO ImportDetail (ImportID, ProductID, SupplierID, Quantity, Price)
    VALUES (@ImportID, @ProductID, @SupplierID, @Quantity, @Price)
END
GO

-- Lấy chi tiết của một phiếu nhập
CREATE PROCEDURE spGetImportDetailsByImportID
    @ImportID INT
AS
BEGIN
    SELECT 
	    id.ImportID,
        id.ProductID,
        id.SupplierID,
        id.Quantity,
        id.Price,
        i.ImportDate
    FROM ImportDetail id
    INNER JOIN [Import] i ON id.ImportID = i.ImportID
    WHERE id.ImportID = @ImportID
END
GO

-- Stored Procedure có kèm transaction
CREATE TYPE ImportDetailsType AS TABLE --Dữ liệu người dùng tự định nghĩa
(
    ProductID INT,
	SupplierID INT,
    Quantity INT,
    Price DECIMAL(18,2)
);
GO
CREATE PROCEDURE CreateFullImport
    @EmployeeID INT,
    @ImportDate DATETIME,
    @TotalCost DECIMAL(18,2),
    @ImportDetail ImportDetailsType READONLY,  -- Table-valued parameter
    @NewImportID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insert vào bảng Order (Không truyền @Status nữa)
        INSERT INTO [Import] (
            EmployeeID, ImportDate, Status, TotalCost
        ) VALUES (
            @EmployeeID, @ImportDate,N'Chờ xử lý', @TotalCost
        );

        -- 2. Lấy ID đơn hàng mới
        SET @NewImportID = SCOPE_IDENTITY();

        -- 3. Insert vào OrderDetails từ Table-Valued Parameter
        INSERT INTO ImportDetail (ImportID, ProductID, SupplierID, Quantity, Price)
        SELECT @NewImportID, ProductID, SupplierID, Quantity, Price
        FROM @ImportDetail;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO