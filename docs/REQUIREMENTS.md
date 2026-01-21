# REQUIREMENTS.md (Business View)

## 1. Current Situation
The organization currently uses isolated software solutions:
- A local desktop application for knowledge management (SQLite-based)
- An unfinished web solution for task management
There is no data connection between problems (Knowledge) and tasks. Management decisions are based on intuition rather than data.

## 2. Objectives
Development of a centralized, cloud-native platform that unifies knowledge management and task planning, enhanced by AI-driven analytics (BI).

## 3. Functional Requirements
- **Centralized Access:** All modules accessible via Single Sign-On (SSO)
- **Knowledge Management:** Capture, search, and categorize support solutions
- **Task Management:** Create tasks with AI-based prioritization
- **Business Intelligence:** Real-time dashboards for KPIs (e.g., "Resolution time per ticket")

## 4. Non-Functional Requirements
- **Scalability:** Microservice-based architecture (containers)
- **Security:** No direct database exposure; API-only communication
- **Modernization:** Replace legacy UI (Desktop) with headless API approach
