# bbs
Bulletin Board System

### <ins>Installation</ins>
First you need to install mysql (mariadb) and a mysql client to install the structure defined in init.sql, I suggest using mariadb-clients:

```bash
$mysql < init.sql
```

Then you simply change the database info in the .bbsrc file and you're all done.

![relational diagram](https://raw.githubusercontent.com/barborik/beta3-bbs/main/sql/rel_diagram.png)
