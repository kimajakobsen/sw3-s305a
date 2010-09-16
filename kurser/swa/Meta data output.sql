select * from pg_tables where schemaname = 'public'


select 'drop table '||tablename||';' as script from pg_tables where schemaname = 'public'