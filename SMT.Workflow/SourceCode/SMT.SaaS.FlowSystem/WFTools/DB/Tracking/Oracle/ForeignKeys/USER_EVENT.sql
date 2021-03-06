ALTER TABLE USER_EVENT
ADD CONSTRAINT FK_USR_EVT_WF_INST
FOREIGN KEY (WORKFLOW_INSTANCE_ID) REFERENCES WORKFLOW_INSTANCE (WORKFLOW_INSTANCE_ID);

ALTER TABLE USER_EVENT
ADD CONSTRAINT FK_USR_EVT_ACT_INST
FOREIGN KEY (ACTIVITY_INSTANCE_ID) REFERENCES ACTIVITY_INSTANCE (ACTIVITY_INSTANCE_ID);

ALTER TABLE USER_EVENT
ADD CONSTRAINT FK_USR_EVT_USR_DT_TYPE
FOREIGN KEY (USER_DATA_TYPE_ID) REFERENCES TYPE (TYPE_ID);