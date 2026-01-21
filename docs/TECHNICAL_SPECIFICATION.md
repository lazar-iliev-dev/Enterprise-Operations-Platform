# TECHNICAL_SPECIFICATION (Developer View)

## 1. System Architecture
The system is implemented as a distributed **microservices architecture** based on **.NET Aspire**.

### Component Diagram
[Your Mermaid diagram here]

## 2. Tech Stack
- **Orchestration:** .NET Aspire (AppHost)
- **Backend Services:** .NET 9 WebAPI (C#)
- **AI Integration:** Python Service (via HTTP/gRPC)
- **Data Persistence:**
  - Knowledge Service: PostgreSQL (Container)
  - Task Service: PostgreSQL (Container)
  - Analytics: DuckDB (OLAP)
- **Gateway:** YARP (Reverse Proxy)

## 3. API Interfaces
- Communication between services is primarily asynchronous or via REST calls
- **External Interface:** Swagger/OpenAPI v3 via YARP Gateway

## 4. Data Model & Migration
- Migration of legacy data from SQLite to PostgreSQL
- Implementation of "Database-per-Service" pattern for data sovereignty

## 5. Business Intelligence (BI)
- ETL pipeline aggregating data into a Data Warehouse (DuckDB)
- Visualization of technical metrics via Grafana (OpenTelemetry)
