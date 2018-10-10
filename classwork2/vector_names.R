# задали векторы
ural_home <- c(2, 0, 1, 0)
ural_away <- c(0, 0, 1, 1)
# напечатали их
print(ural_home)
print(ural_away)
#задали имена для вектора
names(ural_home) <- c("Ufa", "CSKA", "Arsenal", "Anzhi")
# создали новый вектор имен
away_names <- c("Rostov", "Amkar", "Rubin", "Orenburg")
# присвоили именам вектора наш вектор имен
names(ural_away)<-away_names
# еще раз напечатали оба вектора
print(ural_home)
print(ural_away)
# mean - сумма всех эдементов вектора деленная на их число
# sum просто сумма всех элементов вектора
mean(ural_home)
sum(ural_home)
mean(ural_away)
sum(ural_away)
# сравнение двух векторов (выводит false)
identical(ural_home,ural_away)