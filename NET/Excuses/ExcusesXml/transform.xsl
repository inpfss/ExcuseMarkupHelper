<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" />

  <xsl:template match="/">
    <excuses>
      <xsl:for-each select="excuses/excuse">
        <excuse>
          <id>
            <xsl:number value="position()" format="1" />
          </id>
          <xsl:copy-of select="name"/>
          <xsl:copy-of select="author"/>
          <xsl:copy-of select="gender"/>
          <xsl:copy-of select="date"/>
          <xsl:copy-of select="country"/>
          <xsl:copy-of select="text"/>
          <xsl:copy-of select="communicativeTactics"/>
          <xsl:copy-of select="sources"/>
          <xsl:copy-of select="reason"/>
        </excuse>
      </xsl:for-each>
    </excuses>
  </xsl:template>
</xsl:stylesheet>