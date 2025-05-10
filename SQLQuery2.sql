CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        product_id,
        name,
        price,
        stock,
        active
    FROM 
        products;
END;
EXEC GetAllProducts;
