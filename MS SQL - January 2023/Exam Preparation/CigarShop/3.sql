 UPDATE Cigars
 SET PriceForSingleCigar += 0.2 * PriceForSingleCigar
 WHERE TastId = (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

 UPDATE Brands
 SET BrandDescription = 'New description'
 WHERE BrandDescription IS NULL