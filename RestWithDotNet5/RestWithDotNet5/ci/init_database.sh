for i in `find /home/database/ -name "*.sql` | sort --version-sort`;` do mysql -udocker -pdocker rest-dot-net-udemy < $i; done;