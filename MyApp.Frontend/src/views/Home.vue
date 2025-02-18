<template>
  <div class="p-6">
    <h1 class="text-xl font-bold mb-4">Data Grid</h1>

    <!-- Filter Input -->
    <input
      v-model="filter"
      placeholder="Filter data..."
      class="p-2 border rounded mb-4 w-full"
    />

    <!-- Data Table -->
    <table class="w-full border">
      <tr class="bg-gray-200">
        <th class="p-2 text-left">ID</th>
        <th class="p-2 text-left">Value</th>
      </tr>
      <tr v-for="item in filteredData" :key="item.id">
        <td class="p-2">{{ item.id }}</td>
        <td class="p-2">{{ item.value }}</td>
      </tr>
    </table>
  </div>
</template>
<script lang="ts">
    import axios from "axios";
    import { defineComponent, ref, computed, onMounted } from "vue";

    export default defineComponent({
        setup() {
            const data = ref<{ id: number; value: string }[]>([]);
            const filter = ref("");

            // Fetch data from API on mount
            onMounted(async () => {
            try {
                const response = await axios.get("https://localhost:7193/api/Data");
                data.value = response.data;
            } catch (error) {
                console.error("API request failed", error);
            }
            });

            // Computed property to filter data
            const filteredData = computed(() =>
            data.value.filter((item) =>
                item.value.toLowerCase().includes(filter.value.toLowerCase())
            )
            );

            return { data, filter, filteredData };
        },
    });
</script>
<style scoped>
    /* Improve table styling */
    table {
    border-collapse: collapse;
    }
    th, td {
    border: 1px solid #ddd;
    padding: 8px;
    }
    th {
    background-color: #f4f4f4;
    }
</style>
