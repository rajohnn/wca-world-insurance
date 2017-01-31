<?php
$cfg['debug'] = false;

// This is the email address where you will receive the notification message
$cfg['email_address'] = 'epic_virtue@yahoo.com';

$cfg['email_from'] = '';

// The recipients in CC and BCC will receive a copy of the data collected in the form
// Use commas to separate mutiple e-mail addresses (no spaces allowed)
// Example: youraddress1@yourdomain.com,youraddress2@yourdomain.com
$cfg['email_address_cc'] = '';

$cfg['email_address_bcc'] = '';

$cfg['emailsendingmethod'] = 'php';

$cfg['smtp_host'] = '';

$cfg['smtp_port'] = '';

$cfg['smtp_encryption'] = '';

$cfg['smtp_username'] = '';

$cfg['smtp_password'] = '';

$cfg['timezone'] = 'America/New_York';

$cfg['form_id'] = '';

$cfg['form_name'] = 'WIS - Claims Form';

$cfg['form_validationmessage'] = 'Thank you, your claim has been sent to us!<br />We will get back to you as soon as possible.';

$cfg['form_errormessage_captcha'] = '';

$cfg['form_errormessage_emptyfield'] = 'This field cannot be left blank';

$cfg['form_errormessage_invalidemailaddress'] = 'Invalid email address';

$cfg['form_errormessage_invalidurl'] = '';

$cfg['form_errormessage_terms'] = '';

$cfg['form_redirecturl'] = '';

$cfg['adminnotification_subject'] = 'New Claim Submission - worldinsuranceagency.com - {Your Name*|6}';

$cfg['adminnotification_hideemptyvalues'] = false;

$cfg['adminnotification_hideformurl'] = true;

$cfg['usernotification_inputid'] = 'cfgen-element-3-3';

$cfg['usernotification_activate'] = false;

$cfg['usernotification_insertformdata'] = false;

$cfg['usernotification_format'] = '';

$cfg['usernotification_subject'] = '';

$cfg['usernotification_message'] = '';

$cfg['usernotification_hideemptyvalues'] = false;

$cfg['formvalidation_required'] = array('cfgen-element-3-7','cfgen-element-3-6','cfgen-element-3-3','cfgen-element-3-12','cfgen-element-3-13','cfgen-element-3-14','cfgen-element-3-15','cfgen-element-3-8','cfgen-element-3-18','cfgen-element-3-16','cfgen-element-3-9','cfgen-element-3-19','cfgen-element-3-20');

$cfg['formvalidation_email'] = array('cfgen-element-3-3');

?>