# Grafana Json Data source for Cardano Stake Pool Data
JSON API Grafana Datasource for Cardano Stake Pool Data

The code in this repository represents a simple ASP.NET WEB API (.net 6) for [JSON API Grafana Datasource grafana plugin](https://grafana.com/grafana/plugins/simpod-json-datasource/ "JSON plugin").

It's a simple WEB API that implements 3 required endpoints:

GET / with 200 status code response. Used for "Test connection" on the datasource config page. <br/>
POST /search to return available metrics. <br/>
POST /query to return panel data or annotations.

The data for Cardano Pool Metrics is used from https://cexplorer.io/ web site: [https://js.cexplorer.io/api-static/pool/**Stake Pool Id**.json](https://js.cexplorer.io/api-static/pool/pool1w4xhfnhuenzgqqzuldnzrcm4kgpsjv8l0re3p574vg5lv4er0k7.json "Stake Pool Data Source")
