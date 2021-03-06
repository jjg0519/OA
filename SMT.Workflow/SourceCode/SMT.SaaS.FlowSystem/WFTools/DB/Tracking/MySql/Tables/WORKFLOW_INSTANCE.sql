DROP TABLE IF EXISTS WORKFLOW_INSTANCE;
CREATE TABLE WORKFLOW_INSTANCE
(
	WORKFLOW_INSTANCE_ID BIGINT UNSIGNED AUTO_INCREMENT NOT NULL
	,INSTANCE_ID CHAR(36) NOT NULL
	,CONTEXT_GUID CHAR(36) NOT NULL
	,CALLER_INSTANCE_ID CHAR(36) NULL
	,CALL_PATH VARCHAR(400) NULL
	,CALLER_CONTEXT_GUID CHAR(36) NULL
	,CALLER_PARENT_CONTEXT_GUID CHAR(36) NULL
	,WORKFLOW_TYPE_ID BIGINT UNSIGNED NOT NULL
	,INITIALISED_DATE_TIME DATETIME NOT NULL
	,DB_INITIALISED_DATE_TIME DATETIME NOT NULL
	,END_DATE_TIME DATETIME NULL
	,DB_END_DATE_TIME DATETIME NULL
	,PRIMARY KEY  (WORKFLOW_INSTANCE_ID)
);

CREATE INDEX WORKFLOW_INSTANCE_IDX01 ON WORKFLOW_INSTANCE ( WORKFLOW_INSTANCE_ID, CONTEXT_GUID );
CREATE INDEX WORKFLOW_INSTANCE_IDX02 ON WORKFLOW_INSTANCE ( INSTANCE_ID, WORKFLOW_TYPE_ID );