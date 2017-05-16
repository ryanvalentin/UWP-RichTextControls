SELECT '%c%' as Chapter,
  sum(case when ticket.status IN ('new','assigned') then 1 else 0 end) as 'New',
  sum(case when ticket.status='document_interface' then 1 else 0 end) as 'DocumentInterface',
  sum(case when ticket.status='interface_development' then 1 else 0 end) as 'Interface Development',
  sum(case when ticket.status='interface_check' then 1 else 0 end) as 'Interface Check',
  sum(case when ticket.status='document_routine' then 1 else 0 end) as 'Document Routine',
  sum(case when ticket.status='full_development' then 1 else 0 end) as 'Full Development',
  sum(case when ticket.status='peer_review_1' then 1 else 0 end) as 'Peer Review One',
  sum(case when ticket.status='peer_review_2' then 1 else 0 end) as 'Peer Review Two',
  sum(case when ticket.status='qa' then 1 else 0 end) as 'QA',
  sum(case when ticket.status='closed' then 1 else 0 end) as 'Closed',
  count(id) as Total,
  ticket.id as _id
-- One line comment
from
  engine.ticket
  inner join engine.ticket_custom on ticket.id = ticket_custom.ticket
  /*
  Multi line comment
  */
where
  ticket_custom.name='chapter' and
  ticket_custom.value LIKE '%c%' and
  type='New material' and
  milestone='1.1.12' and # another one-liner
  component NOT LIKE 'internal_engine'