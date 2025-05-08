# Game Inventory

## Overview
**GameInventoryCLI** is an interactive command‑line tool for tracking a retail video‑game catalogue.  
The program lets you load or save data in CSV form, add or remove titles, adjust stock counts, and view a neatly formatted inventory table complete with a running total of stock value.  
Its layered design—`View` ↔ `Operations` ↔ `DAL`—makes the code easy to read, extend, and test.


## Features

| Menu  | Action | Process |
|--------|--------|--------------------------------|
| **1** | **Load data** | Reads a CSV file into memory; warns before overwriting current data. |
| **2** | **Save data** | Writes the current repository to a CSV file; prompts before overwrite. |
| **3** | **Add game**  | Captures ID, title, manufacturer, price, and initial stock—with validation. |
| **4** | **Remove game** | Deletes by ID *or* title (case‑insensitive). |
| **5** | **Increase stock** | Adds units to an existing game’s quantity. |
| **6** | **Decrease stock** | Subtracts units (stock may go negative to reflect backorders). |
| **7** | **List all games** | Prints a table of every title and shows **Total Inventory Value** (only positive stock counts). |
| **8** | **Exit** | Graceful shutdown with a goodbye message. |

Robust exception handling ensures that invalid input, file errors, or duplicate entries never crash the application but instead display the error messages.

<hr/>

Clone, forks and pull requests are welcome!



