
select userId, gachaMachineId, trackingDate, noteStatus, email, gachaMachine from trackingList t
join userInfo u
on t.userId = u.id
join gachaMachine g
on t.gachaMachineId = g.id

