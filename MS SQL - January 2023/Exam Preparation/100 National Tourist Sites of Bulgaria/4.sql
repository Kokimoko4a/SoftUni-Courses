DELETE TouristsBonusPrizes
WHERE BonusPrizeId = (SELECT Id FROM BonusPrizes WHERE Name = 'Sleeping bag ')

DELETE BonusPrizes
WHERE Name = 'Sleeping bag'
