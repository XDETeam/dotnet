<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:xde-sp="urn:xde-service-provider"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

  <xsl:template match="/">
    <html>
      <body>
        <xsl:apply-templates />

        <p>
          Test extension object: <xsl:value-of select="xde-sp:TestExtention()"/>
        </p>
      </body>
    </html>
  </xsl:template>

    <xsl:template match="/infrastructure">
    <h1>Infrastructure</h1>

    <xsl:for-each select="service">
      <h2>
        <xsl:value-of select="text()"/>
      </h2>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
