/* POPULATE TABLE tRelatedItem */
insert into tRelatedItem (tObjectId, tObjectRelatedId, tObjectRelatedType, tRelatedItemOrder)
select o.tObjectID, i.tImageID, 1, i.tImageNumOrder from tObject o
inner join tImage i on 
o.tObjectID = i.tObjectID

