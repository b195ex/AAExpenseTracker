select 'Remaining' as Concept, sum(TotalIncome)-sum(totalexpense) as Amount
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
union 
select concept, amount 
from FixExpens 
where User_UserID = 'b195ex@hotmail.com'
union
select concept, amount 
from Expenses 
where User_UserID = 'b195ex@hotmail.com'
