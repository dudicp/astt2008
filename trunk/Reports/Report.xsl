<?xml version="1.0" encoding="ISO-8859-1"?><xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"><xsl:template match="/">

	<html>
		<head>
			<script type='text/javascript' src='collapse.js'></script>
		</head>
		<font face="Mangal">
		<body bgcolor="#EEEEEE">
		<center>
			<i>
				<h1><font size="8px" face="JasmineUPC Bold Italic" color="#00CCFF"><u><xsl:value-of select="Report/@name"/></u></font><br/>
				<font size="6px" face="JasmineUPC Bold Italic" color="#00CCFF">Report</font></h1><br/>
			</i>
			<table border="1px" bordercolor="LightSkyBlue" width="100%">
				<tr bgcolor="LightSkyBlue">
			      <th width="11%" align="center"><i>Action Name</i></th>
			      <th width="11%" align="center"><i>End-Station</i></th>
				  <th width="15%" align="center"><i>Start Time</i></th>
				  <th width="15%" align="center"><i>End Time</i></th>
				  <th width="8%" align="center"><i>Status</i></th>
				  <th width="15%" align="center"><i>Validity String</i></th>
				  <th align="center"><i>Message</i></th>
			    </tr>
			    <xsl:for-each select="Report/Result">
				    <tr>
						<td><xsl:value-of select="ActionName"/></td>
						<td>
							<xsl:value-of select="EndStationName"/>
							(<xsl:value-of select="EndStationID"/>)
						</td>
						<td align="center"><xsl:value-of select="StartTime"/></td>
						<td align="center"><xsl:value-of select="EndTime"/></td>
						<td align="center">
							<xsl:if test="Status='Fail'">
							<font color="#FF1100">
								<b><xsl:value-of select="Status"/></b>
							</font>
							</xsl:if>
							<xsl:if test="Status='Success'">
								<font color="#00EE66">
									<b><xsl:value-of select="Status"/></b>
								</font>
							</xsl:if>
						</td>
						<td align="center"><xsl:value-of select="ValidityString"/></td>
						<td>
							<div class='collapsable'>
								<p>
									<xsl:for-each select="Message/Line">							
										<xsl:value-of select="."/>
										<br/>
									</xsl:for-each>
								</p> 
							</div> 
						</td>
				    </tr>
			    </xsl:for-each>
			</table>
		</center>
		</body>
		</font>
	</html>
</xsl:template></xsl:stylesheet> 
