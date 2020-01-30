select sum(TotalIncome)-sum(totalexpense) as Remaining
from(
	select SUM(amount) TotalIncome, 0 TotalExpense
	from(
		select isnull(sum(amount),0) amount 
		from FixIncoms
		where FixIncoms.User_UserID='b195ex@hotmail.com'
		union
		select isnull(sum(amount),0) amount 
		from Incomes
		where Incomes.User_UserID='b195ex@hotmail.com'
	) as incomes
	union
	select 0 TotalIncome, SUM(amount) TotalExpense
	from(
		select isnull(sum(amount),0) amount 
		from FixExpens
		where User_UserID='b195ex@hotmail.com'
		union
		select isnull(sum(amount),0) amount 
		from Expenses
		where User_UserID='b195ex@hotmail.com'
	) as expenses
) as disposable

select sum(TotalIncome)-sum(totalexpense) as Remaining
from (
	select SUM(amount) TotalIncome, 0 TotalExpense
	from(
		select isnull(sum(amount),0) amount 
		from FixIncoms
		where FixIncoms.User_UserID='Archangel'
		union
		select isnull(sum(amount),0) amount 
		from Incomes
		where Incomes.User_UserID='Archangel'
	) as incomes
	union
	select 0 TotalIncome, SUM(amount) TotalExpense
	from (
		select isnull(sum(amount),0) amount 
		from FixExpens
		where User_UserID='Archangel'
		union
		select isnull(sum(amount),0) amount 
		from Expenses
		where User_UserID='Archangel'
	) as expenses
) as disposable