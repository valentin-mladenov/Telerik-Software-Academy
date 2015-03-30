CREATE DATABASE PerformanceDBTest;

USE PerformanceDBTest;

CREATE TABLE Events(
  EventId int NOT NULL AUTO_INCREMENT,
  EventDate DateTime,
  EventHappend nvarchar(500),
PRIMARY KEY (EventId, EventDate)
)PARTITION BY RANGE(YEAR(EventDate)) (
    PARTITION Before1990 VALUES LESS THAN (1990),
    PARTITION From1990To2000 VALUES LESS THAN (2000),
    PARTITION From2000To2010 VALUES LESS THAN (2010),
    PARTITION From2010ToDate VALUES LESS THAN MAXVALUE
);

DROP TABLE Events;

INSERT INTO Events(EventHappend, EventDate) VALUES
  ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24');

DELIMITER $$
DROP PROCEDURE IF EXISTS add_1000000 $$

CREATE PROCEDURE add_1000000 ()
BEGIN
	DECLARE counter INT DEFAULT 10;
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO Events (EventHappend, EventDate)
		VALUES (CONCAT('Text ', counter, ': Ala bala', counter),
				FROM_UNIXTIME(RAND() * 2147483647));
		SET counter = counter + 1;
	END WHILE;
END $$

CALL add_1000000 ();

SELECT * FROM Events PARTITION (Before1990);
SELECT * FROM Events PARTITION (From1990To2000);
SELECT * FROM Events PARTITION (From2000To2010);
SELECT * FROM Events PARTITION (From2010ToDate);

SELECT * FROM Events;

EXPLAIN PARTITIONS
SELECT * FROM Events WHERE YEAR(1995);